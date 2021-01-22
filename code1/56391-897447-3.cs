    public class NHPagedList<T> : PersistentGenericBag<T>, IPagedList<T>
        {
        public NHPagedList(ISessionImplementor session) : base(session)
        {
            _sessionImplementor = session;
        }
    
        public NHPagedList(ISessionImplementor session, IList<T> collection)
            : base(session, collection)
        {
            _sessionImplementor = session;
        }
    
        private ICollectionPersister _collectionPersister = null;
        public NHPagedList<T> CollectionPersister(ICollectionPersister collectionPersister)
        {
            _collectionPersister = collectionPersister;
            return this;
        }
    
        protected ISessionImplementor _sessionImplementor = null;
    
        public virtual IList<T> GetPagedList(int pageNo, int pageSize)
        {
            if (!this.WasInitialized)
            {
                IQuery pagedList = _sessionImplementor
                    .GetSession()
                    .CreateFilter(this, "")
                    .SetMaxResults(pageSize)
                    .SetFirstResult((pageNo - 1) * pageSize);
    
                return pagedList.List<T>();
            }
    
            return this
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToList<T>();
        }
    
        public new int Count
        {
            get
            {
                if (!this.WasInitialized)
                {
                    return Convert.ToInt32(_sessionImplementor.GetSession().CreateFilter(this, "select count(*)").List()[0].ToString());
                }
    
                return base.Count;
            }
        }
    
    }
