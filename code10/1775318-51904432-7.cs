    var customerId = 1;
    using (var ctx = new DataContext())
    {
        var currentApplication = (
            from customer in ctx.Customers
            where customer.Id == customerId
            select customer.CurrentApplication
        ).FirstOrDefault();
        var pastApplications =
        (
            from customer in ctx.Customers
            from application in customer.Applications
            where customer.Id == customerId && customer.CurrentApplication != application
            select application
        ).ToArray();
    }
