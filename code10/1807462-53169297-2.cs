    List<String> listA = new List<string> { "a", "b", "c", "d", "e", "f", "g" };
    List<String> listB = new List<string> { "1", "2", "3" };
    List<string> listC = new List<string>();
    for (int i = 0; i < Math.Max(listA.Count, listB.Count); i++)
    {
        listC.Add(listA[i % listA.Count]);
        listC.Add(listB[i % listB.Count]);
    }
