    public class OrderRepository : IOrderRepository
    {
        private MyDbContext Context
        {
            return _contextLocator.Get<MyDbContext>() ?? throw new InvalidOperation("The repository must be called from within a context scope.");
        }
    
        IQueryable<Order> IOrderRepository.GetOrders()
        {
            var query = Context.Orders.Where(x => x.IsActive);
            return query;
        }
    
        IQueryable<Order> IOrderRepository.GetOrderById(int orderId)
        {
            var query = Context.Orders.Where(x => x.IsActive && x.OrderId == orderId);
            return query;
        }
    
        Order IOrderRepository.CreateOrder( /* Required references/values */)
        {
        }
    
        void IOrderRepository.DeleteOrder(Order order)
        {
        }
    }
