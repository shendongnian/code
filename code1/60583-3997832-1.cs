    // order (base) class
    public abstract class Order
    {
        private DeliveryStrategy delivery;
    
        protected Order(DeliveryStrategy delivery)
        {
            this.delivery = delivery;
        }
    
        public abstract DeliveryStrategy Delivery
        {
            get { return delivery; }
            protected set { delivery = value; }
        }
    }
    
    public class CustomerOrder : Order
    {
        public CustomerOrder()
            : base(new ParcelDelivery())
        { }
    
        public override ParcelDelivery Delivery
        {
            get { return base.Delivery as ParcelDelivery; }
            set { base.Delivery = value; }
        }
    }
