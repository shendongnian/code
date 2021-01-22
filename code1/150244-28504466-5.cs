    MyConfigSection config = 
       ConfigurationManager.GetSection("registerCompanies") as MyConfigSection;
    Console.WriteLine(config.Instances["Honda Motors"].Code);
    foreach (MyConfigInstanceElement e in config.Instances)
    {
       Console.WriteLine("Name: {0}, Code: {1}", e.Name, e.Code);
    }
