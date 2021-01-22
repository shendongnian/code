    public interface IRepository
    {
        TEntity Get<TEntity, TId>(TId id) where TEntity : EntityObject<TId>
    }
    public abstract class EntityObject<TId>
    {
        public IdT id { get; set; }
    }
    public class Foo : EntityObject<Guid> {} 
