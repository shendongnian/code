        public static T CastEntity<T>(this object entity) where T: class
        {
            var proxy = entity as INHibernateProxy;
            if (proxy != null)
            {
                return proxy.HibernateLazyInitializer.GetImplementation() as T;
            }
            else
            {
                return entity as T;
            }
        }
