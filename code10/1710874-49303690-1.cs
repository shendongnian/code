    var orders = transactionData["orders"]
         .Select(x => new OrderModel
         {
             OrderId = (int)x["orderId"],
             OrderDescription = (string)x["orderDescription"],
             OrderItems = x["orderItems"]
             .Select(y => new OrderDetail //you called it OrderDetailModel
             {
                ProductId = (string)y["productId"],
                ProductName = (string)y["productName"], 
                UnitPrice = (decimal)y["unitPrice"], // casting to decimal but you have a string
                Quantity = (int)y["quantity"]
              }).ToList()
          });
