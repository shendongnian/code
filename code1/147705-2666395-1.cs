    /// <summary>
    /// Returns the real type of the given proxy. If the object is not a proxy, it's normal type is returned.
    /// </summary>
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
