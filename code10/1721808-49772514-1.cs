    public class RootObject
    {
    	[JsonConverter(typeof(StringToObjectConverter<Value>))]
    	public Value value { get; set; }
    	public int nr { get; set; }
    }
    public class Value
    {
    	public string code { get; set; }
    	public string description { get; set; }
    	public bool isSet { get; set; }
    }
