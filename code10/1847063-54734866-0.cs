    private static bool PropertyHasAttribute<T>(string propertyName, Type attributeType)
    {
    	MetadataTypeAttribute att = (MetadataTypeAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(MetadataTypeAttribute));
    	if (att != null)
    	{
    		foreach (var prop in GetType(att.MetadataClassType.UnderlyingSystemType.FullName).GetProperties())
    		{
    			if (propertyName.ToLower() == prop.Name.ToLower() && Attribute.IsDefined(prop, attributeType))
    				return true;
    		}
    	}
    	return false;
    }
