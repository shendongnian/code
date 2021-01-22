    var config = ConfigurationManager.GetSection("registerCompanies") 
                     as MyConfigSection;
    Console.WriteLine(config["Tata Motors"].Code);
    foreach (var e in config.Instances) { 
       Console.WriteLine("Name: {0}, Code: {1}", e.Name, e.Code); 
    }
