    using System;
    using System.Reflection;
    using System.Threading;
    /// <summary>
    /// A generic abstract implementation of the Singleton design pattern (http://en.wikipedia.org/wiki/Singleton_pattern).
    /// 
    /// Derived type must contain a non-public default constructor to satisfy the rules of the Singleton Pattern.
    /// If no matching constructor is found, an exception will be thrown at run-time. I am working on a StyleCop
    /// constraint that will throw a compile-time error in the future.
    /// 
    /// Example Usage (C#):
    /// 
    ///     class MySingleton : Singleton&lt;MySingleton&gt;
    ///     {
    ///         private const string HelloWorldMessage = "Hello World - from MySingleton";
    ///     
    ///         public string HelloWorld { get; private set; }
    ///
    ///         // Note: *** Private Constructor ***
    ///         private MySingleton()
    ///         {
    ///             // Set default message here.
    ///             HelloWorld = HelloWorldMessage;
    ///         }
    ///     }
    /// 
    ///     class Program
    ///     {
    ///         static void Main()
    ///         {
    ///             var mySingleton = MySingleton.Instance;
    ///             Console.WriteLine(mySingleton.HelloWorld);
    ///             Console.ReadKey();
    ///         }
    ///     }
    /// </summary>
    /// <typeparam name="T">Type of derived Singleton object (i.e. class MySingletone: Singleton&lt;MySingleton&gt;).</typeparam>
    public abstract class Singleton<T> where T : class
    {
        /// <summary>
        /// "_instance" is the meat of the Singleton<T> base-class, as it both holds the instance
        /// pointer and the reflection based factory class used by Lazy&lt;T&gt; for instantiation.
        /// 
        /// Lazy&lt;T&gt;.ctor(Func&lt;T&gt; valueFactory,LazyThreadSafetyMode mode), valueFactory:
        /// 
        ///     Due to the fact Lazy&lt;T&gt; cannot access a singleton's (non-public) default constructor and
        ///     there is no "non-public default constructor required" constraint available for C# 
        ///     generic types, Lazy&lt;T&gt;'s valueFactory Lambda uses reflection to create the instance.
        ///
        /// Lazy&lt;T&gt;.ctor(Func&lt;T&gt; valueFactory,LazyThreadSafetyMode mode), mode:
        /// 
        ///     Explanation of selected mode (ExecutionAndPublication) is from MSDN.
        ///     
        ///     Locks are used to ensure that only a single thread can initialize a Lazy&lt;T&gt; instance 
        ///     in a thread-safe manner. If the initialization method (or the default constructor, if 
        ///     there is no initialization method) uses locks internally, deadlocks can occur. If you 
        ///     use a Lazy&lt;T&gt; constructor that specifies an initialization method (valueFactory parameter),
        ///     and if that initialization method throws an exception (or fails to handle an exception) the 
        ///     first time you call the Lazy&lt;T&gt;.Value property, then the exception is cached and thrown
        ///     again on subsequent calls to the Lazy&lt;T&gt;.Value property. If you use a Lazy&lt;T&gt; 
        ///     constructor that does not specify an initialization method, exceptions that are thrown by
        ///     the default constructor for T are not cached. In that case, a subsequent call to the 
        ///     Lazy&lt;T&gt;.Value property might successfully initialize the Lazy&lt;T&gt; instance. If the
        ///     initialization method recursively accesses the Value property of the Lazy&lt;T&gt; instance,
        ///     an InvalidOperationException is thrown.
        /// 
        /// </summary>
        private static readonly Lazy<T> _instance = new Lazy<T>(() =>
                                                                    {
                                                                        // Get non-public constructors for T.
                                                                        var ctors = typeof (T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                                                                        // If we can't find the right type of construcor, throw an exception.
                                                                        if (!Array.Exists(ctors, (ci) => ci.GetParameters().Length == 0))
                                                                        {
                                                                            throw new ConstructorNotFoundException("Non-public ctor() note found.");
                                                                        }
                                                                        // Get reference to default non-public constructor.
                                                                        var ctor = Array.Find(ctors, (ci) => ci.GetParameters().Length == 0);
                                                                        
                                                                        // Invoke constructor and return resulting object.
                                                                        return ctor.Invoke(new object[] {}) as T;
                                                                    }, LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary>
        /// Singleton instance access property.
        /// </summary>
        public static T Instance
        {
            get { return _instance.Value; }
        }
    }
    /// <summary>
    /// Exception thrown by Singleton&lt;T&gt; when derived type does not contain a non-public default constructor.
    /// </summary>
    public class ConstructorNotFoundException : Exception
    {
        private const string ConstructorNotFoundMessage = "Singleton<T> derived types require a non-public default constructor.";
        public ConstructorNotFoundException() : base(ConstructorNotFoundMessage) { }
        public ConstructorNotFoundException(string auxMessage) : base(String.Format("{0} - {1}", ConstructorNotFoundMessage, auxMessage)) { }
        public ConstructorNotFoundException(string auxMessage, Exception inner) : base(String.Format("{0} - {1}", ConstructorNotFoundMessage, auxMessage), inner) { }
    }
