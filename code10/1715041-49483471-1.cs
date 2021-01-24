    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
             Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                    RunAsService();
        }
        else
        {
            RunAsConsole();
        }
     }
