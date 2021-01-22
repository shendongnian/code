    public static IEnumerable<string> GetrandomLines()
    {
        string filepath = "..\\..\\data.txt";
        var readTextFile = ReadLines(filepath);
        var codeGroup = readTextFile.GroupBy(line => line.Substring(line.Length - 2));
        Random rnd = new Random(DateTime.Now.Millisecond);
        foreach (var item in codeGroup)
        {
            yield return item.Skip(rnd.Next(item.Count())).FirstOrDefault();
            yield return item.Skip(rnd.Next(item.Count())).FirstOrDefault();
        }
    }
