    var customersJson = (JArray)result["Items"]["$values"];
    var customers = new List<Customer>();
    foreach (JObject o in customersJson)
    {
         var customerJson = (JArray) o["Properties"]["$values"];
         customers.Add(BuildCustomer(customerJson));
    }
[...]
    private static Customer BuildCustomer(JArray a)
    {
        return new Customer
        {
            ResultRow = GetValue(a, "ResultRow"),
            WorkPhone = GetValue(a, "Work Phone"),
            Email = GetValue(a, "Email"),
            FullName = GetValue(a, "Full Name"),
            iMISId = GetValue(a, "iMISId"),
            PreferredPhone = GetValue(a, "Preferred Phone"),
            Organization = GetValue(a, "Organization")
         };
    }
    
    private static string GetValue(JArray array, string name)
    {
        JToken obj = array.FirstOrDefault(x => (string) x["Name"] == name);
    
        if (obj == null)
            return string.Empty;
    
        return (string) obj["Value"];
    }
