    DefaultContractResolver contractResolver = new DefaultContractResolver
    {
        NamingStrategy = new SnakeCaseNamingStrategy()
    };
    RootobjectSummary result = JsonConvert.DeserializeObject<RootobjectSummary>(summaryResponse.Content, new JsonSerializerSettings
    {
        ContractResolver = contractResolver,
        Formatting = Formatting.Indented
    });
