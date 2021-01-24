    class TransactionManager
    {
        CentralEntities _ctx;
        Hashtable _repositories;
        public TransactionManager(CentralEntities ctx)
        {
            _ctx = ctx;
        }
        public RepositoryTest<T> CreateRepository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();
            var type = typeof(T).Name;
            if (!_repositories.Contains(type))
            {
                var repositoryType = typeof(RepositoryTest<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _ctx);
                _repositories.Add(type,repositoryInstance);
            }
            return (RepositoryTest<T>)_repositories[type];
        }
        public int Save()
        {
            return _ctx.Save();
        }
    }
