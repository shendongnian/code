    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ManagerFacade.GetObject<XManager>(2).ToString());
            Console.WriteLine(ManagerFacade.GetObject<YManager>(4).ToString());
            // pause program execution to review results...
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
