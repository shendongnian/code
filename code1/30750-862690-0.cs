    public static IDictionary ReadDictionaryFile(string fileName)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        foreach (string line in File.ReadAllLines(fileName))
        {
            if ((!string.IsNullOrEmpty(line)) &&
                (!line.StartsWith(";")) &&
                (!line.StartsWith("#")) &&
                (!line.StartsWith("'")) &&
                (line.Contains('=')))
            {
                int index = line.IndexOf('=');
                string key = line.Substring(0, index).Trim();
                string value = line.Substring(index + 1).Trim();
    
                if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                    (value.StartsWith("'") && value.EndsWith("'")))
                {
                    value = value.Substring(1, value.Length - 2);
                }
                dictionary.Add(key, value);
            }
        }
    
        return dictionary;
    }
