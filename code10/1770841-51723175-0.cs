    class Program
    {
        static void Main(string[] args)
        {
            preform().Wait();
            Console.ReadLine();
        }
        public static async Task Working()
        {
            Console.WriteLine("Please wait, the program is running");
        }
        public static async Task Takingtime()
        {
            Console.WriteLine("This Program started");
            await Task.Delay(1000);
            Console.WriteLine("The Program finished");
        }
        public static Task preform()
        {
            return Task.WhenAll(
                Takingtime(),
                Working());
        }
    }
