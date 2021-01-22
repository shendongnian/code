         SortedDictionary<string, SortedDictionary<string, int>> baseItemCounts = new SortedDictionary<string, SortedDictionary<string, int>>();
         baseItemCounts.Add("1450", new SortedDictionary<string, int>());
         baseItemCounts["1450"].Add("1450M", 10);
         baseItemCounts["1450"].Add("1350M", 20);
         baseItemCounts["1450"].Add("1250M", 30);
         foreach (SortedDictionary<string, int> sd in baseItemCounts.Values)
         {
               foreach (int count in sd.Values)
               {
                  Console.WriteLine("{0}", count);
               }
         }
