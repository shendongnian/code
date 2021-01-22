            SortedList<string, List<string>> sl = new SortedList<string, List<string>>();
            List<string> x = new List<string>();
            x.Add("5");
            x.Add("1");
            x.Add("5");
            // use this to load  
            foreach (string z in x)
            {
                if (!sl.TryGetValue(z, out x))
                {
                    sl.Add(z, new List<string>());
                }
                sl[z].Add("F"+z);
            }
            // use this to print 
            foreach (string key in sl.Keys)
            {
                Console.Write("key=" + key + Environment.NewLine);
                foreach (string item in sl[key])
                {
                    Console.WriteLine(item);
                }
            }
