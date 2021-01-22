    abstract class Order {
        public abstract string DeliveryString();
    }
    
    abstract class Order<TDelivery> : Order {
        // methods omitted for brevity
        public override string DeliveryString() {
            return Delivery.ToString();
        }
    }
