    [ClassInitialize]
    public static void ClassInitializer(TestContext context)
    {
        Mapper.Reset();
        AutoMapperDataConfig.Configure();            
    }
