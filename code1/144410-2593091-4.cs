    public class OrderService : IOrderService
    {
        [Authorize]
        [Log]
        [Cache("GetOrder-{0}")]
        public virtual Order GetOrder(int orderID)
        {
            return LookupOrderInDatabase(orderID);
        }
    }
