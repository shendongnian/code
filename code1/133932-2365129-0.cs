    public interface IRepository<TEntity, TId>
     {
          TEntity Get(TId id);
          void Add(T x);
     }
    public interface IUserRepository : IRepository<User, Guid>
    {
        //...
    }
    public interface IOrderRepository : IRepository<Order, string> 
    {
        //...
    }
