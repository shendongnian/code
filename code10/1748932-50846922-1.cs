    using (var tx = new TransactionScope())
    {
      using (var context = new MyDbContext())
      {
         var newCustomer = createNewCustomer(); // dummy method to indicate creating a customer entity.
         context.Customers.Add(newCustomer);
         context.SaveChanges();
         var newOrder = createNewOrder(); 
         newOrder.CustomerId = newCustomer.CustomerId;
         context.Orders.Add(newOrder);
         context.SaveChanges();
      }
      tx.Commit();  
    } 
