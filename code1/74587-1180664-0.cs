    string csvText = File.ReadAllText("C:/Test.txt");
    
    var query = csvText
        .Replace(Environment.NewLine, string.Empty)
        .Replace("\"\"", "\",\"").Split(',')
        .Select((i, n) => new { i, n }).GroupBy(a => a.n / 3);
