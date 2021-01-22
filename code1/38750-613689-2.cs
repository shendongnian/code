            var array = new int[] { 1, 2, 3, 3, 3, 4 };
            // .Net 3.0 - use Dictionary<int, bool> 
            // .Net 1.1 - use Hashtable 
            var set = new HashSet<int>();
            foreach (var item in array) {
                if (!set.Contains(item)) set.Add(item);
            }
            Console.WriteLine("There are {0} distinct values. ", set.Count);
