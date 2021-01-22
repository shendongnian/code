    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Remoting.Contexts;
    using System.Text;
    using System.Web;
    using System.Web.Caching;
    using System.Web.UI;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.Unity.InterceptionExtension;
    
    
    namespace Middleware.Cache
    {
        /// <summary>
        /// An <see cref="ICallHandler"/> that implements caching of the return values of
        /// methods. This handler stores the return value in the ASP.NET cache or the Items object of the current request.
        /// </summary>
        [ConfigurationElementType(typeof (CacheHandler)), Synchronization]
        public class CacheHandler : ICallHandler
        {
            /// <summary>
            /// The default expiration time for the cached entries: 5 minutes
            /// </summary>
            public static readonly TimeSpan DefaultExpirationTime = new TimeSpan(0, 5, 0);
    
            private readonly object cachedData;
    
            private readonly DefaultCacheKeyGenerator keyGenerator;
            private readonly bool storeOnlyForThisRequest = true;
            private TimeSpan expirationTime;
            private GetNextHandlerDelegate getNext;
            private IMethodInvocation input;
    
    
            public CacheHandler(TimeSpan expirationTime, bool storeOnlyForThisRequest)
            {
                keyGenerator = new DefaultCacheKeyGenerator();
                this.expirationTime = expirationTime;
                this.storeOnlyForThisRequest = storeOnlyForThisRequest;
            }
    
            /// <summary>
            /// This constructor is used when we wrap cached data in a CacheHandler so that 
            /// we can reload the object after it has been removed from the cache.
            /// </summary>
            /// <param name="expirationTime"></param>
            /// <param name="storeOnlyForThisRequest"></param>
            /// <param name="input"></param>
            /// <param name="getNext"></param>
            /// <param name="cachedData"></param>
            public CacheHandler(TimeSpan expirationTime, bool storeOnlyForThisRequest,
                                IMethodInvocation input, GetNextHandlerDelegate getNext,
                                object cachedData)
                : this(expirationTime, storeOnlyForThisRequest)
            {
                this.input = input;
                this.getNext = getNext;
                this.cachedData = cachedData;
            }
    
    
            /// <summary>
            /// Gets or sets the expiration time for cache data.
            /// </summary>
            /// <value>The expiration time.</value>
            public TimeSpan ExpirationTime
            {
                get { return expirationTime; }
                set { expirationTime = value; }
            }
           
            #region ICallHandler Members
    
            /// <summary>
            /// Implements the caching behavior of this handler.
            /// </summary>
            /// <param name="input"><see cref="IMethodInvocation"/> object describing the current call.</param>
            /// <param name="getNext">delegate used to get the next handler in the current pipeline.</param>
            /// <returns>Return value from target method, or cached result if previous inputs have been seen.</returns>
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                lock (input.MethodBase)
                {
                    this.input = input;
                    this.getNext = getNext;
    
                    return loadUsingCache();
                }
            }
    
            public int Order
            {
                get { return 0; }
                set { }
            }
    
            #endregion
    
            private IMethodReturn loadUsingCache()
            {
                //We need to synchronize calls to the CacheHandler on method level
                //to prevent duplicate calls to methods that could be cached.
                lock (input.MethodBase)
                {
                    if (TargetMethodReturnsVoid(input) || HttpContext.Current == null)
                    {
                        return getNext()(input, getNext);
                    }
    
                    var inputs = new object[input.Inputs.Count];
                    for (int i = 0; i < inputs.Length; ++i)
                    {
                        inputs[i] = input.Inputs[i];
                    }
    
                    string cacheKey = keyGenerator.CreateCacheKey(input.MethodBase, inputs);
                    object cachedResult = getCachedResult(cacheKey);
    
                    if (cachedResult == null)
                    {
                        var stopWatch = Stopwatch.StartNew();
                        var realReturn = getNext()(input, getNext);
                        stopWatch.Stop();
                        if (realReturn.Exception == null && realReturn.ReturnValue != null)
                        {
                            AddToCache(cacheKey, realReturn.ReturnValue);
                        }
                        return realReturn;
                    }
    
                    var cachedReturn = input.CreateMethodReturn(cachedResult, input.Arguments);
    
                    return cachedReturn;
                }
            }
    
            private object getCachedResult(string cacheKey)
            {
                //When the method uses input that is not serializable 
                //we cannot create a cache key and can therefore not 
                //cache the data.
                if (cacheKey == null)
                {
                    return null;
                }
    
                object cachedValue = !storeOnlyForThisRequest ? HttpRuntime.Cache.Get(cacheKey) : HttpContext.Current.Items[cacheKey];
                var cachedValueCast = cachedValue as CacheHandler;
                if (cachedValueCast != null)
                {
                    //This is an object that is reloaded when it is being removed.
                    //It is therefore wrapped in a CacheHandler-object and we must
                    //unwrap it before returning it.
                    return cachedValueCast.cachedData;
                }
                return cachedValue;
            }
    
            private static bool TargetMethodReturnsVoid(IMethodInvocation input)
            {
                var targetMethod = input.MethodBase as MethodInfo;
                return targetMethod != null && targetMethod.ReturnType == typeof (void);
            }
    
            private void AddToCache(string key, object valueToCache)
            {
                if (key == null)
                {
                    //When the method uses input that is not serializable 
                    //we cannot create a cache key and can therefore not 
                    //cache the data.
                    return;
                }
    
                if (!storeOnlyForThisRequest)
                {
                    HttpRuntime.Cache.Insert(
                        key,
                        valueToCache,
                        null,
                        System.Web.Caching.Cache.NoAbsoluteExpiration,
                        expirationTime,
                        CacheItemPriority.Normal, null);
                }
                else
                {
                    HttpContext.Current.Items[key] = valueToCache;
                }
            }
        }
    
        /// <summary>
        /// This interface describes classes that can be used to generate cache key strings
        /// for the <see cref="CacheHandler"/>.
        /// </summary>
        public interface ICacheKeyGenerator
        {
            /// <summary>
            /// Creates a cache key for the given method and set of input arguments.
            /// </summary>
            /// <param name="method">Method being called.</param>
            /// <param name="inputs">Input arguments.</param>
            /// <returns>A (hopefully) unique string to be used as a cache key.</returns>
            string CreateCacheKey(MethodBase method, object[] inputs);
        }
    
        /// <summary>
        /// The default <see cref="ICacheKeyGenerator"/> used by the <see cref="CacheHandler"/>.
        /// </summary>
        public class DefaultCacheKeyGenerator : ICacheKeyGenerator
        {
            private readonly LosFormatter serializer = new LosFormatter(false, "");
    
            #region ICacheKeyGenerator Members
    
            /// <summary>
            /// Create a cache key for the given method and set of input arguments.
            /// </summary>
            /// <param name="method">Method being called.</param>
            /// <param name="inputs">Input arguments.</param>
            /// <returns>A (hopefully) unique string to be used as a cache key.</returns>
            public string CreateCacheKey(MethodBase method, params object[] inputs)
            {
                try
                {
                    var sb = new StringBuilder();
    
                    if (method.DeclaringType != null)
                    {
                        sb.Append(method.DeclaringType.FullName);
                    }
                    sb.Append(':');
                    sb.Append(method.Name);
    
                    TextWriter writer = new StringWriter(sb);
    
                    if (inputs != null)
                    {
                        foreach (var input in inputs)
                        {
                            sb.Append(':');
                            if (input != null)
                            {
                                //Diffrerent instances of DateTime which represents the same value
                                //sometimes serialize differently due to some internal variables which are different.
                                //We therefore serialize it using Ticks instead. instead.
                                var inputDateTime = input as DateTime?;
                                if (inputDateTime.HasValue)
                                {
                                    sb.Append(inputDateTime.Value.Ticks);
                                }
                                else
                                {
                                    //Serialize the input and write it to the key StringBuilder.
                                    serializer.Serialize(writer, input);
                                }
                            }
                        }
                    }
    
                    return sb.ToString();
                }
                catch
                {
                    //Something went wrong when generating the key (probably an input-value was not serializble.
                    //Return a null key.
                    return null;
                }
            }
    
            #endregion
        }
    }
    
