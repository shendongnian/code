    public class ProxyFactory
    {
        public static TInterface GetInstance<TInterface,TObj>() 
            where TObj : MarshalByRefObject,new()
        {
            TObj proxyObj = Activator.CreateInstance(typeof(TObj)) as TObj;
            return (TInterface)new DynamicProxy<TObj>(proxyObj).GetTransparentProxy();
        }
    }
