       SortedDictionary<string, SortedDictionary<string, int>> baseItemCounts =
      new SortedDictionary<string, SortedDictionary<string, int>>();
            baseItemCounts.Add("1450", new SortedDictionary<string, int>());
            baseItemCounts["1450"].Add("1450M", 15);
            foreach (KeyValuePair<string, SortedDictionary<string, int>> kv in baseItemCounts)
            {
                Console.WriteLine(kv.Key);
                foreach (KeyValuePair<string, int> x in kv.Value)
                    Console.WriteLine(x.Key + "==>" + x.Value);
            }
