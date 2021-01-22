    public static T CreateFrom<T>(this DataTable dt) where T : new()
    {
    	T obj = new T();
    	obj.InitFrom(dt);
    	return obj;
    }
    
    public static void InitFrom<T>(this T obj, DataTable dt)
    {
    	object currentValue;
    	DataRow row = dt[0];
    	
    	foreach(var prop in typeof(T).GetProperties())
    	{
    		currentValue = row[prop.Name];
    		prop.SetValue(obj, currentValue, null);
    	}
    }
