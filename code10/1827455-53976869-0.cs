    public abstract class Entity<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
    }
    public interface IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
        where TKey : struct
    {
    }
