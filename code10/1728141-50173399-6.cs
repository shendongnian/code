    var query = ctx.FooBars
    	.Where(f => f.Id > 240)
    	.Select("new(Name, Path, Id)")
    	.ToJson() // using Newtonsoft.JSON, I know, I know, awful. 
        .FromJson<IEnumerable<FooBar>>()
    	.AsQueryable(); // this is no longer valid or necessary
    return query;
    
    public static T FromJson<T>(this string json)
    {
    	var serializer = new JsonSerializer();
    	using (var sr = new StringReader(json))
    	using (var jr = new JsonTextReader(sr))
    	{
    		var result = serializer.Deserialize<T>(jr);
    		return result;
    	}
    }
    
    public static string ToJson(this object data)
    {
    	if (data == null)
    		return null;
    	var json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
    	return json;
    }
