    var valuesToCompare = dbContext.Customers
        .Select(customer => new
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            ...
            // etc, fill all values you need to check
        })
        .Distinct()                // remove duplicates
        .AsEnumerable();           // make it IEnumerable,
                                   // = efficiently move to local memory
