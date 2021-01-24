        // Create application domain setup information
        var domaininfo = new AppDomainSetup();
        domaininfo.ConfigurationFile = System.Environment.CurrentDirectory + 
                                       Path.DirectorySeparatorChar +
                                       "ADSetup.exe.config";
        domaininfo.ApplicationBase = System.Environment.CurrentDirectory;
        //Create evidence for the new appdomain from evidence of the current application domain
        Evidence adEvidence = AppDomain.CurrentDomain.Evidence;
        // Create appdomain
        AppDomain domain = AppDomain.CreateDomain("Domain2", adEvidence, domaininfo);
        // Display application domain information.
        Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
        Console.WriteLine("Child domain: " + domain.FriendlyName);
        Console.WriteLine();
        Console.WriteLine("Configuration file: " + domain.SetupInformation.ConfigurationFile);
        Console.WriteLine("Application Base Directory: " + domain.BaseDirectory);
        AppDomain.Unload(domain);
    
