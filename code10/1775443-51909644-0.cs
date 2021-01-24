    public class MyData
    {
        public Dictionary<long, Dictionary<long, Dictionary<long, string>>> apps { get; set; }
    }
    var data = JsonConvert.DeserializeObject<MyData>(json);
    // Use 'data.apps'
