    public DependencyFactory(IServiceCollection services)
        {
            _container=services;
        }
     public static T Resolve<T>()
        {
            T ret = default(T);
            var provider = _container.BuildServiceProvider();
           
            if (provider.GetService<T>() !=null)
            {
                ret = (T)provider.GetService<T>();
            }
            return ret;
        }
