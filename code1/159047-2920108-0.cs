    static void Main(string[] args)
        {
            string myString = "qwertyuipasdfghjklzxcvbnm,.~";
            var s = Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++)
            {
                Boolean contains = myString.IndexOf("~", StringComparison.InvariantCultureIgnoreCase) != -1;
            }
            
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++)
            {
                Boolean contains = myString.IndexOf('~') != -1;
            }
            s2.Stop();
            Console.WriteLine(s2.ElapsedMilliseconds);
            Console.ReadLine();
        }
