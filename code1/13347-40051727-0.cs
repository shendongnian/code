    /// <summary>
    /// Loads .ini file into dictionary.
    /// </summary>
    public static Dictionary<String, Dictionary<String, String>> loadIni(String file)
    {
        Dictionary<String, Dictionary<String, String>> d = new Dictionary<string, Dictionary<string, string>>();
        String ini = File.ReadAllText(file);
        // Remove comments, preserve linefeeds, if end-user needs to count line number.
        ini = Regex.Replace(ini, @"^\s*;.*$", "", RegexOptions.Multiline);
        // Pick up all lines from first section to another section
        foreach (Match m in Regex.Matches(ini, "(^|[\r\n])\\[([^\r\n]*)\\][\r\n]+(.*?)(\\[([^\r\n]*)\\][\r\n]+|$)", RegexOptions.Singleline))
        {
            String sectionName = m.Groups[2].Value;
            Dictionary<String, String> lines = new Dictionary<String, String>();
            // Pick up "key = value" kind of syntax.
            foreach (Match l in Regex.Matches(ini, @"^\s*(.*?)\s*=\s*(.*?)\s*$", RegexOptions.Multiline))
            {
                String key = l.Groups[1].Value;
                String value = l.Groups[2].Value;
                // Open up quotation if any.
                value = Regex.Replace(value, "^\"(.*)\"$", "$1");
                
                if (!lines.ContainsKey(key))
                    lines[key] = value;
            }
            if (!d.ContainsKey(sectionName))
                d[sectionName] = lines;
        }
        return d;
    }
