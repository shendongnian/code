    public static void RunService(Func<ServiceBase> factory)
    {
        if (Debugger.IsAttached)
        {
            Utils.AttachConsole();
            Console.Write($"Starting service ");
            var instance = factory();
            Console.WriteLine(instance.GetType().Name);
            //Invoke start Method
            Console.WriteLine("Press [ENTER] to exit");
            Console.ReadLine();
            //Stop service
        }
        else
        {
            ServiceBase.Run(factory());
        }
    }
