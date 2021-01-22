    [IgnoreProperties("EnumValue")]
    public class OrderStatusWrapper
    {
        private OrderStatus _s;
        public int Value
        {
            get{ return (int)_t; }
            set { _t = (OrderStatus)value; }
        }
        public OrderStatus EnumValue
        {
            get { return _t; }
            set { _t = value; }
        }
        public static implicit operator OrderStatusWrapper(OrderStatus r)
        {
            return new OrderStatusWrapper { EnumValue = r };
        }
        public static implicit operator OrderStatus(OrderStatusWrapper rw)
        {
            if (rw == null)
                return OrderStatus.Unresolved;
            else
                return rw.EnumValue;
        }
    }  
