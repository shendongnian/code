            if (entity is INHibernateProxy)
            {
                var lazyInitialiser = ((INHibernateProxy)entity).HibernateLazyInitializer;
                var type = lazyInitialiser.PersistentClass;
                if (type.IsAbstract || type.GetNestedTypes().Length > 0)
                    return Service.Session.GetSessionImplementation().PersistenceContext.Unproxy(entity).GetType();
                else // we don't need to "unbox" the Proxy-object to get the type
                    return lazyInitialiser.PersistentClass;
            }
            return entity.GetType();
