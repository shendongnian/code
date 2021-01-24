    public void Test()
    {
        test = new Dictionary<string, List<string>>();
        test.Add("1", new List<string>() { "a", "b", "c" });
        test.Add("2", new List<string>() { "a", "b", "c" });
        test.Add("3", new List<string>() { "a", "b", "c" });
        test.Add("4", new List<string>() { "a", "b", "c" });
        test.Add("5", new List<string>() { "a", "b", "c" });
        string json = JsonConvert.SerializeObject(test, Formatting.Indented);
        Dictionary<string, List<string>> deserialized = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
    }
