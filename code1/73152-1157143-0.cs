    public static object ObjCopy(object inObj)
    {
    	if( inObj == null ) return null;
    	System.Type type = inObj.GetType();
    
    	if(type.IsValueType)
    	{
    		return inObj;
    	}
    	else if(type.IsClass)
    	{
    		object outObj = Activator.CreateInstance(type);
    		System.Type fieldType;
    		foreach(FieldInfo fi in type.GetFields())
    		{
    			fieldType = fi.GetType();
    			if(fieldType.IsValueType) //Value types get copied
    			{
    				fi.SetValue(outObj, fi.GetValue(inObj));
    			}
    			else if(fieldType.IsClass) //Classes go deeper
    			{
    				//Recursion
    				fi.SetValue(outObj, ObjCopy(fi.GetValue(inObj)));
    			}
    		}
    		return outObj;
    	}
    	else
    	{
    		return null;
    	}
    }
