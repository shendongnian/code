    static void Main(string[] args)
    {
        ReplaceFileContent(@"Input.txt", "01", 45, 2, "0");
        Console.ReadLine();
    }
    public static void ReplaceFileContent(string file, string find, int replaceAt, int replaceLen, string replaceWith)
    {
        var lines = File.ReadAllLines(file).ToList();
        if (lines != null && lines.Count > 0)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Substring(0, find.Length) == find)
                {
                    lines[i] = lines[i].Remove(replaceAt, replaceLen);
                    lines[i] = lines[i].Insert(replaceAt, replaceWith);
                }
            }
        }
        File.WriteAllLines(file, lines);
    }
