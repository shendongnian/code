    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Settings1.Default.Setting);
            Console.ReadLine();
            Settings1.Default.Setting = "A value different from app.config's";
            Settings1.Default.Save();
        }
    }
