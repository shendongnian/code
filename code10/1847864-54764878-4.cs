        static void Main(string[] args)
        {
            Console.WriteLine(RoundTime(new DateTime(2019, 2, 19, 11, 35, 30), 15, 5));
            Console.WriteLine(RoundTime(DateTime.Now, 15, 5));
            Console.ReadLine();
        }
