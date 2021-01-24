    	var testObj = new
	{
	    nameA = "A",
	    ModelB = new
	    {
	        nameB = "B",
	        ModelC = new
	        {
	            NameC = "C",
	        }
	    }
	};
	var result = ParseProperty(testObj, null, "ModelA");
	
	public Dictionary<string, object> ParseProperty(object o, Dictionary<string, object> result, string preFix = null)
	{
	    result = result ?? new Dictionary<string, object>();
	
	    if (o == null) return result;
	
	    Type t = o.GetType();
	    //primitive type or value type  or string or nested return
	    if (t.IsPrimitive || t.IsValueType || t.FullName == "System.String" || t.IsNested) return result;
	
	    var proerties = o.GetType().GetProperties();
	    foreach (var property in proerties)
	    {
	        var value = property.GetValue(o);
	        result.Add($"{preFix}.{property.Name}", value);
	        //nested call
	        ParseProperty(value, result, $"{preFix}.{property.Name}");
	    }
	    return result;
	}
   
