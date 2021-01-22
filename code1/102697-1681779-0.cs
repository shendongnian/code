    customers.ToList().ForEach(g => Console.WriteLine("{0} has {1} customers: {2}",
        g.Country, 
        g.Customers.Count(), 
        string.Join(", ",
            g.Customers.Select((x, i) => i + ". " + x.CompanyName).ToArray())));
