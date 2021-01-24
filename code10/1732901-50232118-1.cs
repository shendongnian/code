    if (File.Exists(@"D:\name.txt"))
    {
        List<string> nameList = File.ReadAllLines(@"D:\name.txt").ToList();
        string sensentence = "find my name";
        int[] indexes = Enumerable.Range(0, nameList.Count).Where(i => nameList[i] == "David").ToArray();
        int shift = 0;
        foreach (var index in indexes)
        {
            nameList.Insert(index + shift, sensentence);
            shift++;
        }
    
        File.WriteAllLines(@"D:\name.txt", nameList);
    }
