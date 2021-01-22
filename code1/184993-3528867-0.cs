        public interface IRepository<out T> where T : EntityBase { //or "in" depending on the items.
        }
        public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase {
        }
        public class MyEntityRepository : RepositoryBase<MyEntity> {
        }
        ...
        IRepository<EntityBase> baseRepo = (IRepository<EntityBase>)myEntityRepo;
