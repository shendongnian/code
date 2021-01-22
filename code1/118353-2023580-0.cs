    class Order {
        public int OrderNumber { get; private set; }
        public Address ShippingAddress { get; private set; }
        public Address BillingAddress { get; private set; }
        private readonly IList<OrderLine> OrderLines { get; private set; }
        public void AddItem(Item item, int quantity) {
            OrderLine orderLine = new OrderLine(item, quantity);
            OrderLines.Add(orderLine);
        }
        // constructor etc.
    }
    class OrderLine {
        public Item Item { get; private set; }
        public int Quantity { get; private set; }        
        public OrderLine(Item item, int quantity) {
            Item = item;
            Quantity = quantity;
        }
    }
