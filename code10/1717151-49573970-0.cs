    static void Main(string[] args)
    {
        using (StreamReader r = new StreamReader(@"\model.json")) // json path
        {
            string json = r.ReadToEnd();
    
            var deserializedJson = JsonConvert.DeserializeObject<Result>(json, new ItemConverter());
        }
    }
