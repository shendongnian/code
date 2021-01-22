    public interface IRepository<TEntity, TId>
     {
          TEntity Get(TId id);
          void Add(T x);
     }
    public interface IUserRepository : IRepository<User, Guid>
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
    public interface IOrderRepository : IRepository<Order, string> 
    {
        //...
    }
