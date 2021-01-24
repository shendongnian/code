    var items = listOfObjects.FromJson<IEnumerable<IDictionary<string, string>>>();
    
    var info = objectInfo.FromJson<IEnumerable<IDictionary<string, string>>>()
        .ToLookup(it => it.Single(k => k.Key == "name").Value, it => it.Where(k => k.Key != "name"));
    
    var restructured = items
    	.SelectMany(it => it.Keys)
    	.GroupBy(it => it)
    	.Select(it => new
    	{
    		Key = it.Key,
    		Value = info[it.Key].SelectMany(fo => fo).ToDictionary(fo => fo.Key, fo => fo.Value)
    	})
    	.ToDictionary(it => it.Key, it => it.Value);
    
    // extension method with NewtonSoft.JSON.net
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
