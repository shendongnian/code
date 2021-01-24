    public class GetNumbers
    {
    	[JsonExtensionData]
        public Dictionary<string,object> Values;
    	[JsonIgnore]
    	public Dictionary<string,Exampleget> ExamplegetDictionary=> Values.Select(x=>new KeyValuePair<string,Exampleget>(x.Key, ((object)x.Value).Cast<Exampleget>()))
    																	  .ToDictionary(x=>x.Key,y=>y.Value);
     	
    }
    
    public static class Extension
    {
    	public static T Cast<T>(this object value)
    	{
    		var jsonData = JsonConvert.SerializeObject(value);
          	return JsonConvert.DeserializeObject<T>(jsonData);
    	}
    }
