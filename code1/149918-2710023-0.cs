    List<KeyValuePair<string, int>> results = new List<KeyValuePair<string, int>>();
    foreach (string line in File.ReadAllLines("input.txt"))
    {
        Match match = Regex.Match(line, @"^\s*{\s*(.*?)\s*;\s*(\d+)\s*}\s*$");
        if (match.Success)
        {
            string s = match.Groups[1].Value;
            int i = int.Parse(match.Groups[2].Value);
            results.Add(new KeyValuePair<string,int>(s,i));
        }
    }
    foreach (var kvp in results)
        Console.WriteLine("{0} ; {1}", kvp.Key, kvp.Value);
