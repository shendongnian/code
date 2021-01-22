    public class PagedListFactory<T> : IUserCollectionType
    {
        public PagedListFactory()
        { }
        #region IUserCollectionType Members
        public bool Contains(object collection, object entity)
        {
            return ((IList<T>)collection).Contains((T)entity);
        }
        public IEnumerable GetElements(object collection)
        {
            return (IEnumerable)collection;
        }
        public object IndexOf(object collection, object entity)
        {
            return ((IList<T>)collection).IndexOf((T)entity);
        }
        public object Instantiate(int anticipatedSize)
        {
            return new PagedList<T>();
        }
        public IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister)
        {
            return new NHPagedList<T>(session);
        }
        public object ReplaceElements(object original, object target, ICollectionPersister persister, 
                object owner, IDictionary copyCache, ISessionImplementor session)
        {
            IList<T> result = (IList<T>)target;
            result.Clear();
            foreach (object item in ((IEnumerable)original))
            {
                result.Add((T)item);
            }
            return result;
        }
        public IPersistentCollection Wrap(ISessionImplementor session, object collection)
        {
            return new NHPagedList<T>(session, (IList<T>)collection);
        }
        #endregion
    }
