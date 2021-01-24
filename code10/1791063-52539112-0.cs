    public class WebSocketOrderBroadcaster : IOrderBroadcaster
    {
        private IHubContext<OrderHub> orderHubContext;
        public WebSocketOrderBroadcaster(IHubContext<OrderHub> orderHubContext)
        {
            this.orderHubContext = orderHubContext;
        }
        public Task SendUpdate(string order)
        {
            return this.orderHubContext.Clients.All.SendAsync("Update", order);
        }
    }
