    static void Main(string[] args)
    {
        List<string> TableNames = new List<string>() { "Table1", "Table3", "Table5", "Table7" };
        var files = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.cs", SearchOption.AllDirectories);
        List<string> results = new List<string>();
        foreach (var file in files)
        {
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    var contents = sr.ReadToEnd();
                    var result = TableNames.FindAll(contents.Contains);
                    if (result.Count > 0)
                    {
                        var fileName = Path.GetFileName(file);
                        foreach (var table in result)
                        {
                            results.Add(string.Format("{0},{1}", table, fileName));
                        }
                    }
                }
            }
        }
        Console.ReadLine();
    }
