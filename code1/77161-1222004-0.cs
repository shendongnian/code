     var orderNumbers = ... your list ...
     using (var dataContext = new OrdersDataContext()) // designer-generated context
     {
         var orderTitles = dataContext.Orders
                                      .Where( o => orderNumbers.Contains( o.OrderNumber ) )
                                      .Select( o => o.OrderTitle );
         ... now do something with the collection...
     }
