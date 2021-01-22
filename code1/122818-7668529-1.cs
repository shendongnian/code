    // 1: Save after iteration (recommended approach in most cases)
    using (var context = new MyContext())
    {
        foreach (var person in context.People)
        {
            // Change to person
        }
        context.SaveChanges();
    }
    
    // 2: Declare an explicit transaction
    using (var transaction = new TransactionScope())
    {
        using (var context = new MyContext())
        {
            foreach (var person in context.People)
            {
                // Change to person
                context.SaveChanges();
            }
        }
        transaction.Complete();
    }
    
    // 3: Read rows ahead (Dangerous!)
    using (var context = new MyContext())
    {
        var people = context.People.ToList(); // Note that this forces the database
                                              // to evaluate the query immediately
                                              // and could be very bad for large tables.
    
        foreach (var person in people)
        {
            // Change to person
            context.SaveChanges();
        }
    } 
