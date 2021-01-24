    public class Repository<T, TKey> : IRepository<T, TKey>
        where T : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        private List<T> _context;
        public Repository(List<T> context)
        {
            _context = context;
        }
        public T GetById(TKey id)
        {
            return _context.Single(m => m.Id.Equals(id));
        }
    }
