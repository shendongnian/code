    Test test = new Test();
    
    PropertyInfo[] properties = typeof(Test).GetProperties();
        foreach (var prop in properties)
        {
    		var type = prop.GetType();
    		if(type is bool)
    		{	
    			prop.SetValue(test, false);
    		}
        }
