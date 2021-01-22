    public static void Main(string[] args)
    {
    AppDomain appDomain = AppDomain.CreateDomain("NewAppDomain");
    appDomain.DoCallBack(new CrossAppDomainDelegate(AsmLoad));
    
    // At this point, your assembly is locked, you can't delete
    
    AppDomain.Unload(appDomain);
    Console.WriteLine("AppDomain unloaded");
    
    //You've completely unloaded your assembly. Now if you want, you can delete the same
    
    }
    
    public static void AsmLoad()
    {
    Assembly assembly = Assembly.LoadFrom(@"c:\Yourassembly.dll");
    
    //Loaded to the new app domain. You can do some stuff here
    Console.WriteLine("Assembly loaded in {0}",AppDomain.CurrentDomain.FriendlyName);
    }
