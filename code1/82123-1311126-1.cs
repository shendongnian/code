    var query = customers
        .SelectMany
        (
            c => c.Orders
                .SelectMany(o => o.Items)
                .Select(i => new { Customer = c, i.ItemCode })
                .Distinct()
        )
        .GroupBy(x => x.ItemCode, x => x.Customer);
    // and to quickly display the results...
    foreach (var result in query)
    {
        Console.WriteLine("Item code: " + result.Key);
        Console.Write("Bought by: ");
        foreach (var customer in result)
        {
            Console.Write(customer.Name + ", ");
        }
        Console.WriteLine();
        Console.WriteLine("----------");
    }
