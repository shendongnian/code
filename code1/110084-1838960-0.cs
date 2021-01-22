    // get the name of the assembly
    string exeAssembly = Assembly.GetEntryAssembly().FullName;
    
    // setup - there you put the path to the config file
    AppDomainSetup setup = new AppDomainSetup();
    setup.ApplicationBase = System.Environment.CurrentDirectory;
    setup.ConfigurationFile = "<path to your config file";
    
    // create the app domain
    AppDomain appDomain = AppDomain.CreateDomain("My AppDomain", null, setup);
    
    // create proxy used to call the startup method 
    YourStartupClass proxy = (YourStartupClass)appDomain.CreateInstanceAndUnwrap(
           exeAssembly, typeof(YourStartupClass).FullName);
    
    // call the startup method - something like alternative main()
    proxy.StartupMethod();
    
    // in the end, unload the domain
    AppDomain.Unload(appDomain);
