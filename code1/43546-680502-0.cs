    IQueryable<Customers> source=context.Customers;
    
    if (...)
    {
      source = from c in source
               where c.FirstName.StartsWith("Jim")
               select c;
    }
    if (...)
    {
      source = from c in source
               where contries.Contains(c.Country)
               select c;
    }
    // ...
