    string s = "N:Pay in Cash++RGI:40++R:200++";
    
    // Replace "++" with ","
    s.Replace("++",",");
    
    // Divide all pairs (remove empty strings)
    string[] tokens = s.Split(new char[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
    
    Dictionary<string, string> d = new Dictionary<string, string>();
    
    for (int i = 0; i < tokens.Length; i += 2)
    {
        string key = tokens[i];
        string value = tokens[i + 1];
    
        d.Add(key,value);
    }
