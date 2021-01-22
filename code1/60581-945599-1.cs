    public class CustomerOrder : Order
    {
        public CustomerOrder()
            : base(new ParcelDelivery())
        { }
    
        public ParcelDelivery Delivery
        {
            get { return (ParcelDelivery)base.Delivery; }
        }
    
    
        DeliveryStrategy IOrder.Delivery
        {
            get { return base.Delivery}
        }
    }
