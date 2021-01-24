    model.Addresses.Add(new Address
    {
        Id = 1,
        Street = "123 Main Street",
        City = "Birmingham",
        State = "AL",
        PostalCode = "35201",
        Country = "USA"
    });
    foreach (var person in model.People)
    {
        person.AddressId = 1;
    }
    json = JsonConvert.SerializeObject(model, Formatting.Indented);
    Console.WriteLine(json);
