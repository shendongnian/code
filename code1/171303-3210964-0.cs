        List<byte> bytes = new List<byte>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        int partLength = 4;
        int c = bytes.Count / partLength;
        if((c % partLength) != 0)
            c++; // we need one last list which will have to be filled with 0s
        List<List<byte>> allLists = new List<List<byte>>();
        for (int i = 0; i <= c; i++)
            allLists.Add(bytes.Take(partLength).ToList());
        int zerosNeeded = partLength - allLists.Last().Count;
        for (int i = 0; i < zerosNeeded; i++)
            allLists.Last().Add(0);
