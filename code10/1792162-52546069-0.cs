        public interface IOrderRepository : IRepository<Order>
    {
    Order Add(Order order);
    // ...
    }
