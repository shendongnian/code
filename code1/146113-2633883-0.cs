    Customer customer = myObjectContext.Single(c => c.Name == "Bob");
    
    //new up an Order instance that has never been in the database.
    Order order = GetOrderForCar();
    
    //Add order to the Orders ObjectSet of a Customer
    // This connects order to our ObjectContext.
    customer.Orders.Add(order);
    
    myObjectContext.SaveChanges();
