    var groupByYearMonth = customers.GroupBy(customer => 
         new DateTime(customer.PurchaseDate.Year, customer.PurchaseDate.Month, 1);
    foreach (var group in groupByYear)
    {
        Console.WriteLine("Year/month: {0}/{1}", group.Key.Year, group.Key.Month);
        foreach (var customer in group)
        {
            Console.WriteLine("{0}: {1}", customer.ID, customer.Name);
        }
    }
