    string stringRepresentationOfObj = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
            {
                OverrideSpecifiedNames = false
            }
        }
    });
