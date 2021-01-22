    public class Order
    {
        public int OrderTypeInt;
        public OrderTypeEnum OrderType
        {
            get { return (OrderTypeEnum)OrderTypeInt; }
            set { OrderTypeInt = (int)value; }
        }
    }
