    class Program
    {
        static void Main(string[] args)
        {
            // Setup information for the new appdomain.
            AppDomainSetup setup = new AppDomainSetup();
            setup.ConfigurationFile = "C:\\my.config";
            // Create the new appdomain with the new config.
            AppDomain d2 = AppDomain.CreateDomain("customDomain", AppDomain.CurrentDomain.Evidence, setup);
            // Call the write config method in that appdomain.
            CrossAppDomainDelegate del = new CrossAppDomainDelegate(WriteConfig);
            d2.DoCallBack(del);
            
            // Call the write config in our appdomain.
            WriteConfig();
            Console.ReadLine();
        }
        static void WriteConfig()
        {
            // Get our config file.
            Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Write it out.
            Console.WriteLine("{0}: {1}", AppDomain.CurrentDomain.FriendlyName, c.FilePath);
        }
    }
