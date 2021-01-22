        static void Main()
        {
            TimeSpan ts = TimeSpan.FromTicks(28000000000);
            double minutesFromTs = ts.TotalMinutes;
            Console.WriteLine(minutesFromTs);
            Console.Read();
        }
