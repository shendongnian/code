    public class OrdersIndex : Raven.Client.Documents.Indexes.AbstractIndexCreationTask<Order>
    {
         public OrdersIndex()
         {
               Map = orders => from order in orders
                               select new
                               {
                                   Property1 = order.Property1.Replace(" ", "-"),
                                   Property2 = order.Property2.Replace(" ", "-"),
                                   Property3 = order.Property3.Replace(" ", "-"),
                               };
         }
    }
