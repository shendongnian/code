        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            var n = 0;
            while (DateTime.Now < startTime.AddSeconds(4))
            {
                var key = Console.ReadKey();
                System.Threading.Thread.Sleep(1);
                if (key.Key == ConsoleKey.Spacebar) n = n + 1;
            }
            Console.WriteLine($"You pressed spacebar {n} times ");
        }
