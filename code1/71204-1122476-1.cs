    DataRelation orderRelation = orderData.Relations["Order_OrderDetails"];
    
    foreach (DataRow order in orders.Rows)
    {
       Console.WriteLine("Subtotals for Order {0}:", order["OrderNumber"]);
    
       foreach (DataRow orderDetail in order.GetChildRows(orderRelation))
       {
          Console.WriteLine("Order Line {0}: {1}", orderDetail["OrderLineNumber"], string.Format("{0:C}", orderDetail["Price"]));
       }
    }
