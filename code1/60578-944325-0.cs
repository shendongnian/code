    public abstract class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery Delivery { ... }
        ...
    }
    public class CustomerOrder : Order<ParcelDelivery>
    {
        ...
    }
