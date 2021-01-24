    var initialList = new[]
    {
        "test", "test2", "test3", "test4", "test5", "test6", "test7", "test8", "test9", "test10", "test11",
        "test12"
    };
    
    var newLists = new List<IEnumerable<string>>();
    var rnd = new Random();
    int minMentions = 2;
    int maxMentions = 3;
    int c = 0;
    
    while (c < initialList.Length)
    {
        int elementsToTake = rnd.Next(minMentions, maxMentions + 1);
        newLists.Add(initialList.Skip(c).Take(elementsToTake));
        c += elementsToTake;
    }
