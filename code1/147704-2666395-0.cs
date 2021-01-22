    internal static Type GetRealType(this object proxy)
    {
        if (proxy is INHibernateProxy)
        {
            var lazyInitialiser = ((INHibernateProxy)proxy).HibernateLazyInitializer;
            return lazyInitialiser.PersistentClass;
        }
        else
        {
            return proxy.GetType();
        }
    }
