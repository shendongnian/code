    // first put data of all files in a list:
    List<string[]> fileData = new List<string[]>();
    for (int i = 0; i < filepaths.Length; i++)
    {
        string file = filepaths[i];
        string[] lines = File.ReadAllLines(file);
        fileData.Add(lines);
    }
    //then combine them horizontally in another list
    List<string> combined = new List<string>();
    var maxCount = fileData.Max(x=>x.Length);
    for (int i = 0; i < maxCount ; i++)
    {
        combined.Add(string.Join(",", fileData.Select(x => x.Length > i ? x[i] : "")));
    }
