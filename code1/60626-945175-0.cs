    abstract class Order {
        public abstract string DeliveryString();
    }
    
    abstract class Order<TDelivery> {
        // methods omitted for brevity
        public override string DeliveryString() {
            return Delivery.ToString();
        }
    }
