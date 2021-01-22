        static Random rand = new Random();
        static int NextSpecial(this Random r, int multiplier)
        {
            return r.Next(0, 10) * multiplier;
        }
        static string randomString()
        {
            return (rand.NextSpecial(10000000) +
                   rand.NextSpecial(1000000) +
                   rand.NextSpecial(100000) +
                   rand.NextSpecial(10000) +
                   rand.NextSpecial(1000) +
                   rand.NextSpecial(100) +
                   rand.NextSpecial(10) +
                   rand.NextSpecial(1))
                   .ToString().PadLeft(8,'0');
        }
        static void Main()
        {
            int MAXITEMS = 1000000;
            IList<string> numbers = new List<string>(MAXITEMS);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITEMS; i++)
            {
                numbers.Add(randomString());
            }
            sw.Stop();
            Console.WriteLine("{0} iterations took: {1}", MAXITEMS.ToString(), sw.Elapsed);
            
            File.WriteAllLines(@"c:\test.txt", numbers.ToArray());
            Console.ReadLine();
        }
