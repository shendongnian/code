    var orders = transactionData["orders"]
         .Select(x => new OrderModel
         {
             OrderId = (int)x["orderId"],
             OrderDescription = (string)x["orderDescription"],
             OrderItems = x["orderItems"]
             .Select(y => new OrderDetailModel
             {
                ProductId = (string)y["productId"],
                ProductName = (string)y["productName"], 
                UnitPrice = (decimal)y["unitPrice"], // casting to decimal but you have a string
                Quantity = (int)y["quantity"]
              }).ToList()
          });
    public class OrderModel
        {
            public int OrderId { get; set; }
            public string OrderDescription { get; set; }
            public List<OrderDetailModel> OrderItems { get; set; } // Collection of OrderDetails
        }
        
    public class OrderDetailModel
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
        }
