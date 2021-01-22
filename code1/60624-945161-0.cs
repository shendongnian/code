    public abstract class Order
    {
        public abstract String GetDeliveryMethod();
    }
    public abstract class Order<TDelivery> : Order
        where TDelivery : DeliveryStrategy
    {
        .... the rest of your class
        public override String GetDeliveryMethod()
        {
            return Delivery.ToString();
        }
    }
