    public static void Main()
    {
    	var arrayExp = GetArray();
    	var newCollection = ArrayExp.ToList().Select(x => RedefineObject(x, "Id"));
    }
    
    static object[] GetArray()
    {
    	var person1 = new { Name = "name", Id = 1 };
    	var person2 = new { Name = "name", Id = 2 };
    	var person3 = new { Name = "name", Id = 3 };
    	return new[] { person1, person2, person3 };
    }
    
    static object RedefineObject(object obj, string propertyToRemove)
    {
    	var properties = obj.GetType().GetProperties().Where(x => x.Name != propertyToRemove);
    
    	var dict = new Dictionary<string, object>();
    	var eobj = new ExpandoObject();
    	var eoColl = (ICollection<KeyValuePair<string, object>>)eobj;
    
    	properties.ToList().ForEach(x => dict.Add(x.Name, x.GetValue(obj)));
    
    	dynamic dynObj = dict;
    	return dynObj;
    }
