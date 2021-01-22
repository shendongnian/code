    var groupByYear = customers.GroupBy(customer => customer.PurchaseDate.Year);
    foreach (var group in groupByYear)
    {
        Console.WriteLine("Year: {0}", group.Key);
        foreach (var customer in group)
        {
            Console.WriteLine("{0}: {1}", customer.ID, customer.Name);
        }
    }
