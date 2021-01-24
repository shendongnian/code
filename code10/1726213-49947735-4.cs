    static void Main(string[] args)
    {
        string environmentName = "QA";
        EnvironmentSpecificContainer container = new EnvironmentSpecificContainer(new AssemblyCatalog(Assembly.GetCallingAssembly()), environmentName);
        
        var tmp = container.GetExportedValue<object>("MefTest.Consumer");
    }
