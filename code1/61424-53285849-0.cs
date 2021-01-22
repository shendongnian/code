    	public static void loopAttributes(PropertyInfo prop, string targetAttribute, object tempObject)
		{
			foreach (PropertyInfo nestedProp in prop.PropertyType.GetProperties())
			{
				if(nestedProp.Name == targetAttribute)
				{
					//found the matching attribute
				}
				loopAttributes(nestedProp, targetAttribute, prop.GetValue(tempObject);
				
			}
		}
    //in the main function
    foreach (PropertyInfo prop in rootObject.GetType().GetProperties())
    {
	    loopAttributes(prop, targetAttribute, rootObject);
    }
