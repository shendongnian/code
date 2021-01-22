    using Castle.DynamicProxy;
    
    namespace Magna.Client.Common.Proxy
    {
        public class ProxyDtoUtils
        {
            public static T GetUnderlying<T>(T proxy)
            {
                return ProxyUtil.IsProxy(proxy) ? (T)ProxyUtil.GetUnproxiedInstance(proxy) : proxy;
            }
        }
    }
