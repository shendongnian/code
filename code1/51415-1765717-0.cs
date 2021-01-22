    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Loop timing test: loading collection...");
            List<int> l = new List<int>();
            for (long i = 0; i < 60000000; i++)
            {
                l.Add(Convert.ToInt32(i));
            }
            Console.WriteLine("Collection loaded with {0} elements: start timings",l.Count());
            Console.WriteLine("\n<===============================================>\n");
            Console.WriteLine("foreach loop test starting...");
            DateTime start = DateTime.Now;
            //l.ForEach(x => l[x].ToString());
            foreach (int x in l)
                l[x].ToString();
            Console.WriteLine("foreach Loop Time for {0} elements = {1}", l.Count(), DateTime.Now - start);
            Console.WriteLine("\n<===============================================>\n");
            Console.WriteLine("List.ForEach(x => x.action) loop test starting...");
            start = DateTime.Now;
            l.ForEach(x => l[x].ToString());
            Console.WriteLine("List.ForEach(x => x.action) Loop Time for {0} elements = {1}", l.Count(), DateTime.Now - start);
            Console.WriteLine("\n<===============================================>\n");
            Console.WriteLine("for loop test starting...");
            start = DateTime.Now;
            int count = l.Count();
            for (int i = 0; i < count; i++)
            {
                l[i].ToString();
            }
            Console.WriteLine("for Loop Time for {0} elements = {1}", l.Count(), DateTime.Now - start);
            Console.WriteLine("\n<===============================================>\n");
            Console.WriteLine("\n\nPress Enter to continue...");
            Console.ReadLine();
        }
