    public static IEnumerable<string> GetTwoRandomLines(string filePath)
    {
        var codeGroup = ReadLines(filePath)
            .GroupBy(line => line.Substring(line.Length - 2));
        Random rnd = new Random(DateTime.Now.Millisecond);
        foreach (var item in codeGroup)
        {
            yield return item.Skip(rnd.Next(item.Count())).FirstOrDefault();
            yield return item.Skip(rnd.Next(item.Count())).FirstOrDefault();
        }
    }
