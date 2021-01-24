    string text = @"What is the value of pn in 1 ;/
    This is a test 12./ lop";
    string pattern = @"\d\s?[.,;:]\s?/";
    var lines = Regex.Split(text, "\r\n|\r|\n").Where(s => s != String.Empty)
        .ToList();
    for (int i = 0; i < lines.Count; i++)
    {
        foreach (Match m in Regex.Matches(lines[i], pattern))
        {
            Console.WriteLine(string.Format("{0},{1}", i + 1, m.Index + 1));
        }
    }
