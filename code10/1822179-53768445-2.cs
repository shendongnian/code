	// Cache the contract resolver statically for best performance.
    var resolver = new ConfigurableContractResolver()
        .Configure((s, e) => { e.Contract.ConfigurePerson(); });
    var settigs = new JsonSerializerSettings
    {
        ContractResolver = resolver,
    };
    var person = new Person
    {
        FirstName = "George",
        LastName = "Washington"
    };
    var serialized = JsonConvert.SerializeObject(person, settigs);
