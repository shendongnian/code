    List<String> listA = new List<string> { "a", "b", "c", "d", "e", "f", "g" };
    List<String> listB = new List<string> { "1", "2", "3" };
    List<string> listC = new List<string>();
    int min = Math.Min(listA.Count, listB.Count);
    for (int i = 0; i < Math.Max(listA.Count, listB.Count); i++)
    {
        listC.Add(listA[i % Math.Max(listA.Count,min)]);
        listC.Add(listB[i % Math.Max(listB.Count,min)]);
    }
