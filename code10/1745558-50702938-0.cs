    var list1 = new List<int> { 50, 100, 14, 57, 48, 94 }
    var list2 = new List<string> { "A", "B", "C", "D", "E", "F" };
    var dict = new SortedDictionary<int, string>();
    
    for (int i = 0; i < list1.Count; i++)
    {
       dict.Add(list1[i], list2[i]);
    }
