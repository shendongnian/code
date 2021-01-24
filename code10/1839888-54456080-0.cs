    var customers = new[]
    {
        new Customer{ Id = 1, Resp_Id = 1, Name = "Fatafehi" },
        new Customer{ Id = 2, Resp_Id = 2, Name = "Dan" },
        new Customer{ Id = 3, Resp_Id = 1, Name = "Anthony" },
        new Customer{ Id = 4, Resp_Id = 1, Name = "Sekona" },
        new Customer{ Id = 5, Resp_Id = 1, Name = "Osotonu" },
        new Customer{ Id = 6, Resp_Id = 6, Name = "Robert" },
        new Customer{ Id = 7, Resp_Id = 1, Name = "Lafo" },
        new Customer{ Id = 8, Resp_Id = 1, Name = "Sarai" },
        new Customer{ Id = 9, Resp_Id = 9, Name = "Esteban" },
        new Customer{ Id = 10, Resp_Id = 10, Name = "Ashley" },
        new Customer{ Id = 11, Resp_Id = 11, Name = "Mitch" },
        new Customer{ Id = 12, Resp_Id = 64, Name = "Mark" },
        new Customer{ Id = 13, Resp_Id = 11, Name = "Shawn" },
        new Customer{ Id = 14, Resp_Id = 53, Name = "Kathy" },
        new Customer{ Id = 15, Resp_Id = 53, Name = "Jasmine" },
        new Customer{ Id = 16, Resp_Id = 16, Name = "Aubrey" },
        new Customer{ Id = 17, Resp_Id = 17, Name = "Peter" },
        new Customer{ Id = 18, Resp_Id = 18, Name = "Eve" },
        new Customer{ Id = 19, Resp_Id = 19, Name = "Brenna" },
        new Customer{ Id = 20, Resp_Id = 20, Name = "Shanna" },
        new Customer{ Id = 21, Resp_Id = 21, Name = "Andrea" },
    };
    var billings = new[]
    {
        new Billing{ Id = 2, Day30 = null, Day60 = null },
        new Billing{ Id = 6, Day30 = null, Day60 = null },
        new Billing{ Id = 9, Day30 = null, Day60 = null },
        new Billing{ Id = 10, Day30 = null, Day60 = null },
        new Billing{ Id = 11, Day30 = null, Day60 = null },
        new Billing{ Id = 64, Day30 = null, Day60 = null },
        new Billing{ Id = 53, Day30 = null, Day60 = null },
        new Billing{ Id = 16, Day30 = null, Day60 = null },
        new Billing{ Id = 17, Day30 = null, Day60 = null },
        new Billing{ Id = 18, Day30 = null, Day60 = null },
        new Billing{ Id = 19, Day30 = null, Day60 = null },
        new Billing{ Id = 20, Day30 = -36.52, Day60 = null },
        new Billing{ Id = 21, Day30 = 1843.30, Day60 = null },
    };
    var aggregate = customers.GroupJoin(
        billings, 
        customer => customer.Resp_Id, 
        billing => billing.Id, 
        (customer, AllBills) => new
        {
            customer.Id,
            customer.Resp_Id,
            customer.Name,
            AllBills
        });
    foreach (var item in aggregate)
    {
        Console.WriteLine($"{item.Id.ToString().PadLeft(2)}   {item.Resp_Id.ToString().PadLeft(2)}   {item.Name}");
        if(!item.AllBills.Any())
            Console.WriteLine("No bills found!");
        foreach (var bill in item.AllBills)
        {
            Console.WriteLine($"   {bill.Id.ToString().PadLeft(2)}   {bill.Day30}   {bill.Day60}");
        }
        Console.WriteLine();
    }
    Console.WriteLine("Finished");
    Console.ReadKey();
