    public class Response
    {
        [JsonProperty("transactionData")]
        public TransactionData TransactionData { get; set; }
    }
    public class TransactionData
    {
        [JsonProperty("orders")]
        public List<Order> Orders { get; set; } 
    }
    public class Order
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }
        [JsonProperty("orderDescription")]
        public string OrderDescription { get; set; }
        [JsonProperty("orderItems")]
        public List<OrderDetail> OrderItems { get; set; } // Collection of OrderDetails
    }
    public class OrderDetail
    {
        [JsonProperty("productId")]
        public string ProductId { get; set; }
        [JsonProperty("productName")]
        public string ProductName { get; set; }
        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
