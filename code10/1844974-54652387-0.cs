    public class JsonExample
    {
        public int VALUE { get; set; }
        public string ATTRIBUTE { get; set; }
    }
    public void GetJson()
    {
        string json = "your string";
        var xpto = JsonConvert.DeserializeObject<List<JsonExample>>(json);
    }
