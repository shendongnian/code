    public class TestDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>
        where TEntity : class
    {
        ObservableCollection<TEntity> _data;
        IQueryable _query;
        public TestDbSet()
        {
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }
        public override EntityEntry<TEntity> Add(TEntity item)
        {
            _data.Add(item);
            var entity = base.Attach(item);
            return entity;
        }
    }
