    using (MSBLegacyContext db = new MSBLegacyContext())
    {
         var TestOrder = db.Orders
                        .FirstOrDefault(i=>i.OrderID == orderId);
         if (TestOrder != null)
         {
            var orderId = TestOrder.OrderId;
            // ...
         }
         // else whatever you would do
    }
