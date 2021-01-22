    CustomerCollection customers = new CustomerCollection();
    customers.Add(new Customer() { Name = "Adam" });
    customers.Add(new Customer() { Name = "Bonita" });
    foreach (Customer c in customers.Where<Customer>(c => c.Name == "Adam"))
    {
        Console.WriteLine(c.Name);
    }
