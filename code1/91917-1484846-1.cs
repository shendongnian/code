    const String fileName = @"foo.ini";
    const String entryExpression = @"^\s*(?<key>[a-zA-Z][a-zA-Z0-9]*)\s*=" + 
                                   @"\s*(?<value>[a-zA-Z][a-zA-Z0-9]*)\s*$";
    
    Dictionary<String,String> entries = new Dictionary<String, String>();
    
    foreach (String line in File.ReadAllLines(fileName))
    {
        Match match = Regex.Match(line, entryExpression);
    
        if (match.Success)
        {
            String key = match.Groups["key"].Value;
            String value = match.Groups["value"].Value;
    
            if (entries.ContainsKey(key))
            {
                Console.WriteLine("Overwriting the key '{0}'.", key);
            }
    
            entries[key] = value;
        }
        else
        {
            Console.WriteLine("Detected malformed entry '{0}'.", line);
        }
    }
