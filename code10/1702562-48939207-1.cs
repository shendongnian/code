    var settings = new JsonSerializerSettings
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
    };
    foreach (var property in typeof(Person).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
    {
        Console.WriteLine("Property {0}: Json name = \"{1}\", IsIgnored = {2}", property, settings.GetPropertyName(typeof(Person), property.Name), settings.GetIsIgnored(typeof(Person), property.Name));
    }
