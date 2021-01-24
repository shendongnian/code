    public static Document ConvertObjectToDocument<TEntity>(this TEntity obj) where TEntity : class
    {
    	var dynamicDoc = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(obj));
    
    	using (JsonReader reader = new JTokenReader(dynamicDoc))
    	{
    		var document = new Document();
    		document.LoadFrom(reader);
    		return document;
    	}
    }
