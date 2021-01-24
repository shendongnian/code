    List<Customer> customersResult = customers.Select(x => new Customer {
        ID = x.ID,
        Name = x.Name,
        Contacts = x.Contacts?.Where(c => c.IsValid).ToList()
    }).ToList();
