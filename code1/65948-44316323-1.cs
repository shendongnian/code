    public static T CopyClass<T>(T obj)
    {
	    T objcpy = (T)Activator.CreateInstance(typeof(T));
	    foreach (var prop in obj.GetType().GetProperties())
        {
    	    var value = prop.GetValue(obj);
            objcpy.GetType().GetProperty(prop.Name).SetValue(objcpy, value);
        }
	    return objcpy;
