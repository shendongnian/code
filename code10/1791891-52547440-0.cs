        public class Order
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
    }
