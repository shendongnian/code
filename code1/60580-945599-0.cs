    public interface IOrder
    {
        public DeliveryStrategy Delivery
        {
            get;
        }
    }
    
    // order (base) class
    public abstract class Order : IOrder
    {
        protected readonly DeliveryStrategy delivery;
    
        protected Order(DeliveryStrategy delivery)
        {
            this.delivery = delivery;
        }
    
        public DeliveryStrategy Delivery
        {
            get { return delivery; }
        }
    }
