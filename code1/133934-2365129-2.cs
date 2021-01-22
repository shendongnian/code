    public interface IRepository<TEntity, TId>
     {
          TEntity Get(TId id);
          void Add(T x);
     }
    public class UserRepository : IRepository<User, Guid>
    {
        public User Get( Guid id ) 
        {
            // ...
        }
        public void Add( User entity) 
        {
            // ...
        }
    }
    public class OrderRepository : IRepository<Order, string> 
    {
        //...
    }
