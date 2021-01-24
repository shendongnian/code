    public class OrderService : IOrderService
    {
        private IOrderBroadcaster broadcaster;
        public OrderService(IOrderBroadcaster broadcaster)
        {
            this.broadcaster = broadcaster;
        }
        public void UpdateOrder(string order)
        {
            this.broadcaster.SendUpdate(order);
        }
    }
