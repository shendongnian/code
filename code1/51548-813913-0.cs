    // get the value from the database
    var original = ctx.Customers.First(c => c.ID == customer.ID);
    // copy values from the changed entity onto the original.
    ctx.ApplyPropertyChanges(customer); .
    ctx.SaveChanges();
