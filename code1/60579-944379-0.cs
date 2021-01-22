    public abstract class Order
    {
        protected Order(DeliveryStrategy delivery)
        {
            Delivery = delivery;
        }
        public virtual DeliveryStrategy Delivery { get; protected set; }
    }
    public class CustomerOrder : Order
    {
        public CustomerOrder()
            : base(new ParcelDelivery())
        { }
        public DeliveryStrategy Delivery { get; protected set; } 
    }
