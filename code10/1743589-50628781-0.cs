    void Main()
    {
    	var json = @"{""offset"":""0001-01-01T00:00:00""}";
    	var ds = Newtonsoft.Json.JsonConvert.DeserializeObject<TestDS>(json);
    	Console.WriteLine(ds);
    }
    public class TestDS {
    	[Newtonsoft.Json.JsonProperty("offset", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    	public DateTimeOffset? DSOffset { get; set; }
    }
