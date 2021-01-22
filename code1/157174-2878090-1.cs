    SortedDictionary<string, List<string>> dic = new SortedDictionary<string, List<string>>();
    foreach (string fileName in fileNames)
    {
       string extension = Path.GetExtension(fileName);
       List<string> list;
       if (!dic.TryGetValue(extension, out list))
       {
          list = new List<string>();
          dic.Add(extension, list);
       }
       list.Add(fileName);
    }
    string[] arr = dic.Values.SelectMany(v => v).ToArray();
