    public class OrderView
    {
        private readonly Order order;
        public OrderView(Order order)
        {
            this.order = order;
        }
        public Decimal SubTotal { get { return this.order.SubTotal; } }
        public String CustomerCity { get { return this.order.Customer.City; } }
        // ...
    }
