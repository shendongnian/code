        static void Main(string[] args)
        {
            List<List<int>> stuff = new List<List<int>>();
            for (int count = 0; count < 3; count++)
            {
                List<int> list = new List<int>();
                list.AddRange(new int[] { 1, 2, 4 });
                stuff.Add(list);
            }
            Console.WriteLine($"stuff is a list of {stuff.Count} items");
            Console.WriteLine($"the first list item in stuff has {stuff[0].Count} items");
            Console.ReadKey();
        }
