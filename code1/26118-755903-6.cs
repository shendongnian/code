    public static T CastEntity<T>(this T entity)
    {
        INhibernateProxy proxy = entity as INHibernateProxy;
        if (proxy != null)
        {
            return (T)proxy.HibernateLazyInitializer.GetImplementation();
        } 
        else
        {
            return (T)entity;
        }
    }
