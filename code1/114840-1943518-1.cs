     SortedDictionary<int, SortedDictionary<string, List<string>>> list = 
         new SortedDictionary<int, SortedDictionary<string, List<string>>>();
     list.Add(2, new SortedDictionary<string, List<string>>());
     list[2].Add("1000", new List<string>() { "a", "b", "c" });
     list[2].Add("2000", new List<string>() { "b", "c" });
     list.Add(4, new SortedDictionary<string, List<string>>());
     list[4].Add("1000", new List<string>() { "z" });
     list[4].Add("3000", new List<string>() { "y" });
     list.MergeKeys(2, 4);
