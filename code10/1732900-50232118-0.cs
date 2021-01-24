    if (File.Exists(@"C:\name.txt"))
    {
        string content = File.ReadAllText(@"C:\name.txt");
        string sensentence = "find my name";
        List<string> nameList = content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        int[] indexes = Enumerable.Range(0, nameList.Count).Where(i => nameList[i] == "David").ToArray();
        int shift = 0;
        foreach (var index in indexes)
        {
            nameList.Insert(index + shift, sensentence);
            shift++;
        }
    
        File.WriteAllLines(@"C:\name.txt", nameList);
    }
