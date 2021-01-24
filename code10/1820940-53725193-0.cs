    public class MyOrderIndexes: AbstractIndexCreationTask<Order>
    {    
        public MyOrderIndexes()
        {
            Map = Orders => from Order in Orders
                                     select new
                                     {
                                           Id = Order.Id,
                                           MyOrders = Order.MyOrders
                                     };
        }
    }
