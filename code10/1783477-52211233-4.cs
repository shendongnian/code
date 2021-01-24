    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public List<OrderItem> Items { get; set; }
    }
    
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }
    }
