	public class ProxyCreator
    {
        public static T MakeINotifyPropertyChanged<T>() where T : class, new()
        {
            var proxyGen = new ProxyGenerator();
            var proxy = proxyGen.CreateClassProxy(
              typeof(T),
              new[] { typeof(INotifyPropertyChanged) },
              ProxyGenerationOptions.Default,
              new NotifierInterceptor()
              );
            return proxy as T;
        }
    }
    
