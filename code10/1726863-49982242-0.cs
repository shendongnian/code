    class Program
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1);
        static void Main(string[] args)
        {
            
            DateTime epoch = new DateTime(1970, 1, 1);
            int count = 10000;
            Stopwatch s1 = new Stopwatch();
            Stopwatch s2 = new Stopwatch();
            Stopwatch s3 = new Stopwatch();
            s3.Start();
            var e = _epoch;
            s3.Stop();
            s1.Start();
            for (int i = 0; i < count; i++)
            {
                var x = DateTime.UtcNow.Subtract(_epoch).TotalSeconds;
            }
            s1.Stop();
            s2.Start();
            for (int i = 0; i < count; i++)
            {
                var x = DateTime.UtcNow.Subtract(epoch).TotalSeconds;
            }
            s2.Stop();
            Console.WriteLine(s3.ElapsedTicks);
            Console.WriteLine(s1.ElapsedTicks);
            Console.WriteLine(s2.ElapsedTicks);
            Console.ReadLine();
        }
    }
