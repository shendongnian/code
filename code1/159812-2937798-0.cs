    string filename = "R285476COMP_SU1_125A6025_20100407_123456.txt";
	
    Match m = Regex.Match(filename,
        @"^(R\d+(?:COMP|CRIT))_(?:SU\d+_)?(\d+[A-Z]+\d+)_(?:SU\d+_)?(\d{8})_.*$",
        RegexOptions.IgnoreCase);
    if (m.Success)
    {
        Console.WriteLine(m.Groups[1].Value);    // R285476COMP
        Console.WriteLine(m.Groups[2].Value);    // 125A6025
        Console.WriteLine(m.Groups[3].Value);    // 20100407
    }
