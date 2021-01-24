    public static List<JObject> GetObjectByValue(string filePath, string matchValue)
    {
        var text = File.ReadAllText(filePath);
    
        var pattern = @"\[(.*?)\]";
    
        var matches = Regex.Matches(text, pattern);
    
        List<JObject> jObjects = new List<JObject>();
    
        Parallel.For(0, matches.Count, i =>
        {
            JArray jArray = JArray.Parse(matches[i].Value);
            var res = jArray.ToObject<JObject[]>().Where(x => x.Properties().Any(y => y.Name == "sym" && y.Value.ToString() == matchValue)).ToList();
            jObjects.AddRange(res);
        });
    
        return jObjects;
    }
