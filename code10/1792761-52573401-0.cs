    public class EntityBase
    {
        public int Id { get; set; }
    }
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        ...
    }
