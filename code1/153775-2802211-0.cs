    public void ReflectList(object o, PropertyInfo p, ReflectedListAttribute rla)
    {
    	IEnumerable e = p.GetValue(o, null) as IEnumerable;
    
    	int count = 0;
    	if (e != null)
    	{
    		foreach (object lo in e)
    		{
    			if (count >= rla.MaxRows)
    				break;
    			ReflectObject(lo, count);
    			count++;
    		}
    	}
    }
