    DataSet orderData = new DataSet("OrderData");
    
    orderData.Tables.Add(orders);
    orderData.Tables.Add(orderDetails);
    
    orderData.Relations.Add("Order_OrderDetails", orders.Columns["OrderNumber"], orderDetails.Columns["OrderNumber"]);
