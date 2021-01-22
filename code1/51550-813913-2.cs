    ctx.Customers.MergeOption = MergeOption.NoTracking;
    var customer = ctx.Customers.First();
    // make changes to the customer in the form
    ctx.AttachAsModified("Customers", customer);
    ctx.SaveChanges();
