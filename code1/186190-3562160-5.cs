    // Dynamically build simple expression:
    new Hyperlinq (QueryLanguage.Expression, "123 * 234").Dump();
    
    // Dynamically build query:
    new Hyperlinq (QueryLanguage.Expression, @"from c in Customers
    where c.Name.Length > 3
    select c.Name", "Click to run!").Dump();
