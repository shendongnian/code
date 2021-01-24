    public static JObject GetObjectByValue(string filePath, string matchValue)
    {
        var text = File.ReadAllText(filePath);
        var pattern = @"\[(.*?)\]";
        var matches = Regex.Matches(text, pattern);
        var result = matches.Cast<Match>()
                .Select(a => JArray.Parse(a.Value))
                .Select(b => b.ToObject<JObject[]>())
                .Where(x => x.Properties()
                             .Any(y => y.Name == "sym" && y.Value.ToString() == matchValue))
                             .FirstOrDefault()
                .FirstOrDefault();   //<= .ToList() to return all matching objects
        return result;
    }
    
