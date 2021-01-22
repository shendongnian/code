    [TestClass]
    public class WhenReadyToDispatch{
    
    private Order order;
    
    [TestInitialize]
    public void Initialize
    {
         order = <create an order>
        order.DeliveryAddress = <create an address>
    }
    [TestMethod]
    CanChangeOrderDeliveryAddress()
    {
        
        order.DeliveryAddress = address;
    }
    
    [TestMethod]
    CanDispatchAnOrder()
    {
        order.Dispatch();
    }
    
    }
