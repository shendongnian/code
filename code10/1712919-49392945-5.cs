    var customers = new List<CustomerBase> {
        new GoldCustomer("Frank"),
        new SilverCustomer("Jack")
    };
    foreach (CustomerBase c in customers) {
        Console.WriteLine($"{c.Name} is {c.Type}");
    }
