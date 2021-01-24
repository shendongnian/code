    public void AddJsonObject(object obj)
    {
    	var jsonObj = JObject.Parse(External.Serialize(obj));
    	foreach (var property in jsonObj.Properties())
    	{
    		External.AddParameter(property.Name, External.Serialize( property.Value));
    	}
    }
