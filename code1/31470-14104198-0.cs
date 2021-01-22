    public static T GetEnumeratedItem<T>(Object items, int index) where T : class
    {
      T item = null;
      if (items != null)
      {
    	System.Reflection.MethodInfo mi = items.GetType()
    	  .GetMethod("GetEnumerator");
    	if (mi != null)
    	{
    	  object o = mi.Invoke(items, null);
    	  if (o != null)
    	  {
    		System.Reflection.MethodInfo mn = o.GetType()
    		  .GetMethod("MoveNext");
    		if (mn != null)
    		{
    		  object next = mn.Invoke(o, null);
    		  while (next != null && next.ToString() == "True")
    		  {
    			if (index < 1)
    			{
    			  System.Reflection.PropertyInfo pi = o
    				.GetType().GetProperty("Current");
    			  if (pi != null) item = pi
    				.GetValue(o, null) as T;
    			  break;
    			}
    			index--;
    		  }
    		}
    	  }
    	}
      }
      return item;
    }
