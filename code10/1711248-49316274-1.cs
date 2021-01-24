    public interface IEntity
    {
       Guid Id { get; set; }
    }
    public class DbAction<TEntity> : IDbAction<TEntity> where TEntity: class, IEntity, new()
    {
        public void InsertData(TEntity entity)
        {
            ...
        }
    }
