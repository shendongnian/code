    void Main()
    {
        var collection = JsonConvert.DeserializeObject<LanguagesCollection>(File.ReadAllText(@"c:\temp\test.json"));
        foreach (var keyValuePair in collection.Languages)
            if (keyValuePair.Key.StartsWith("ja_"))
                keyValuePair.Value.Dump();
            
    }
    
    public class LanguagesCollection
    {
        public Dictionary<string, JObject> Languages { get; } = new Dictionary<string, JObject>();
    }
