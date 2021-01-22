    public class OrderView
    {
        private readonly Order order;
        public OrderView(Order order)
        {
            this.order = order;
        }
        public Decimal Total { get { return this.order.Total; } }
        public String CustomerCity { get { return this.order.Customer.City; } }
        // ...
    }
