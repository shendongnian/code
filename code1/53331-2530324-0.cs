    public static IConfiguration ConfigureReplication()
    {
        IConfiguration db4oConfig = Db4oFactory.NewConfiguration();
        db4oConfig.GenerateUUIDs(ConfigScope.Globally);
        db4oConfig.GenerateVersionNumbers(ConfigScope.Globally);
        return db4oConfig;
    }
