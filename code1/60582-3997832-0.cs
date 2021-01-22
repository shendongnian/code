    // order (base) class
    public abstract class Order
    {
        private DeliveryStrategy delivery;
    
        protected Order(DeliveryStrategy delivery)
        {
            this.delivery = delivery;
        }
    
        public DeliveryStrategy Delivery
        {
            get 
            {
                Console.WriteLine("Order");
                return delivery; 
            }
            protected set { delivery = value; }
        }
    }
    
    public class CustomerOrder : Order
    {
        public CustomerOrder()
            : base(new ParcelDelivery())
        { }
    
        // 'new' Delivery property
        public new ParcelDelivery Delivery
        {
            get 
            {
                Console.WriteLine("CustomOrder");
                return base.Delivery as ParcelDelivery; 
            }
            set { base.Delivery = value; }
        }
    }
