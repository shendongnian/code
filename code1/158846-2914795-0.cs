            foreach (string key1 in baseItemCounts.Keys)
            {
                foreach (string key2 in baseItemCounts[key1].Keys)
                {
                    Console.WriteLine("{0}, {1}, {2}", key1, key2, baseItemCounts[key1][key2]);
                }
            }
