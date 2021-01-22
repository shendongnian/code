    System.Resources.ResourceManager mgr = new
        System.Resources.ResourceManager("MyConsoleApp.MyResource",
        System.Reflection.Assembly.GetExecutingAssembly()) ;
    Console.WriteLine ( mgr.GetString ("resourceName"));
    Console.ReadLine ();
    
