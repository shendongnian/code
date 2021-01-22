    using Newtonsoft.Json;
    static class typeExtensions
    {
	    [Extension()]
    	public static T jsonCloneObject<T>(T source)
	    {
		string json = JsonConvert.SerializeObject(source);
		return JsonConvert.DeserializeObject<T>(json);
	    }
    }
