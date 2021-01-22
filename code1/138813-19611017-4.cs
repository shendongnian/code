    static void Main(string[] args)
    {
        while(true)
        {
            Console.WriteLine(ConfigurationManager.AppSettings["test"]);
            Thread.Sleep(1000);
        }
    }
