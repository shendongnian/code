public class Root
{
    [JsonProperty("results")]
    public Result Results { get; set; }
}
public class Result
{
    [JsonProperty("records")]
    public Dictionary<string, Record> Records { get; set; }
}
public class Record
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
}
var data = JsonConvert.DeserializeObject<Root>(json);
