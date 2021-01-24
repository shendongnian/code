    public interface IRepository<T>
    {
        void Create(Entity<T> entity);
        IEnumerable<Entity<T>> ReadAll();
    }
    public abstract class Entity<T>
    {
        protected IRepository<T> repository;
        public void Create()
        {
            repository.Create(this);
        }
        public IEnumerable<Entity<T>> ReadAll()
        {
            return repository.ReadAll();
        }
    }
