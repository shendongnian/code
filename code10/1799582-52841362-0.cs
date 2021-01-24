    public class Data
    {
    	public string variable2 { get; set; }
    
    	// pick one: dictionart should be favored, unless you have no-unique keys
    
    //	[JsonConverter(typeof(CustomListKvpConverter<int, string>))]
    //	public List<KeyValuePair<int, string>> variable1 { get; set; }
    //
    //	[JsonConverter(typeof(CustomDictionaryKvpConverter<int, string>))]
    //	public Dictionary<int, string> variable1 { get; set; }
    }
    
    public class CustomListKvpConverter<TKey, TValue> : JsonConverter<List<KeyValuePair<TKey, TValue>>>
    {
    	public override List<KeyValuePair<TKey, TValue>> ReadJson(JsonReader reader, Type objectType, List<KeyValuePair<TKey, TValue>> existingValue, bool hasExistingValue, JsonSerializer serializer)
    	{
    		return JArray.Load(reader)
    			.ToObject<Dictionary<TKey, TValue>[]>()
    			.SelectMany(x => x)
    			.ToList();
    	}
    
    	public override void WriteJson(JsonWriter writer, List<KeyValuePair<TKey, TValue>> value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
    public class CustomDictionaryKvpConverter<TKey, TValue> : JsonConverter<Dictionary<TKey, TValue>>
    {
    	public override Dictionary<TKey, TValue> ReadJson(JsonReader reader, Type objectType, Dictionary<TKey, TValue> existingValue, bool hasExistingValue, JsonSerializer serializer)
    	{
    		return JArray.Load(reader)
    			.ToObject<Dictionary<TKey, TValue>[]>()
    			.SelectMany(x => x)
    			.ToDictionary(x => x.Key, x => x.Value);
    	}
    
    	public override void WriteJson(JsonWriter writer, Dictionary<TKey, TValue> value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
