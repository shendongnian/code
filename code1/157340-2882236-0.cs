    [ServiceContact]
    public OrdersResult SubmitOrders(OrdersInfo)
    
    [DataContract]
    public class OrdersInfo
    {
      Order[] Orders;
    }
    [DataContract]
    public class OrdersResult
    {
      .....
    }
