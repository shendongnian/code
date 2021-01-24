    var matches = Regex.Matches(s, "_+");
    var result = new List<int>();
    foreach(Match m in matches)
    {
    	result.Add(m.Index);
    	result.Add(m.Index + m.Length - 1);
    }
    Console.WriteLine(String.Join(", ", result));
