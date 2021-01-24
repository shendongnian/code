    class Program
    {
        static void Main(string[] args)
        {
            var dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory");
            Console.WriteLine(dataDirectory);
            Console.ReadKey();
        }
    }
