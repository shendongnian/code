        public interface IEntity
        {
        }
    
        public interface IEntity<T> : IEntity 
               where T : IEntity
        {
        }
    
        public class BaseEntity<T> : IEntity 
               where T : IEntity, IEntity<T> 
        {
        }
    
        public interface IRepository<T> 
               where T: IEntity
        {
            void Create(T entity);
            IEnumerable<T> ReadAll();
        }
    
        public class Entity<T> : BaseEntity<T> 
              where T: IEntity, 
                       IEntity<T>, 
                       IEquatable<Entity<T>>        
        {
            protected IRepository<IEntity> repository;
            
            public virtual void Create()
            {
                repository.Create(this);
            }
    
            public bool Equals(Entity<T> other)
            {
                throw new NotImplementedException();
            }
        }
