    Guid[] categoryIdsOfNewCustomer; // passed as part of the create command
    
    var newCustomer = new Customer();
    newCustomer.Categories = Context.Categories
        .Where(c => categoryIdsOfNewCustomer.Contains(c.Id))
        .ToList();
    Context.Customers.Add(newCustomer);
    Context.SaveChanges();
