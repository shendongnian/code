    protected static XmlSerializer SerializerGet(System.Type type)
    {
    	XmlSerializer output = null;
    	lock(typeof(SerializeAssist))
    	{
    		if(serializerList.ContainsKey(type))
    		{
    			output = serializerList[type];
    		}
    		else
    		{
    			if(type == typeof(object) || type == typeof(object[]) || type == typeof(ArrayList))
    			{
    				output = new XmlSerializer(type, objArrayTypes);
    			}
    			else
    			{
    				output = new XmlSerializer(type);
    			}
    			serializerList.Add(type, output);
    		}
    	}
    	return output;
    }
