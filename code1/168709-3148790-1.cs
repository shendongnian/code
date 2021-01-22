    class Program    
    {
        static void Main()
        {
            string[] a = new string[]
            {
                "Egyptian",
                "Indian",
                "American",
                "Chinese",
                "Filipino",
            };
            Array.Sort(a);
            foreach (string s in a)
            {
                Console.WriteLine(s);
            }
        }
    }
