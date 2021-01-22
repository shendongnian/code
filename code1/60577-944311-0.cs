    // order (base) class
    public abstract class Order<TDeliveryStrategy> where TDeliveryStrategy : DeliveryStrategy
    {
        private TDeliveryStrategy delivery;
    
        protected Order(TDeliveryStrategy delivery)
        {
            this.delivery = delivery;
        }
    
        public TDeliveryStrategy Delivery
        {
            get { return delivery; }
            protected set { delivery = value; }
        }
    }
    
    public class CustomerOrder : Order<ParcelDelivery>
    {
        public CustomerOrder()
            : base(new ParcelDelivery())
        { }
    }
