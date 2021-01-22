    // you'll need to populate these two variables
    var configuration = GetConfiguration();
    var assembly = GetAssemblyContainingConfig();
    using(new AddinCustomConfigResolveHelper(assembly))
    {
        return (MyConfigSection)configuration.GetSection("myConfigSection");
    }
