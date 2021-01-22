    void main()
    {
    	var serializer = GetDataContractSerializer<MyObjectWithCascadingInterfaces>();
    	using (FileStream stream = new FileStream(xmlPath, FileMode.Open))
    	{
    		XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());
    		var obj = (MyObjectWithCascadingInterfaces)serializer.ReadObject(reader);
    	
    		// your code here
    	}
    }
    
    DataContractSerializer GetDataContractSerializer<T>() where T : new()
    {
    	Type[] types = GetTypesForInterfaces<T>();
    
    	// Filter out duplicates
    	Type[] result = types.ToList().Distinct().ToList().ToArray();
    
    	var obj = new T();
    	return new DataContractSerializer(obj.GetType(), types);
    }
    
    Type[] GetTypesForInterfaces<T>() where T : new()
    {
    	return GetTypesForInterfaces(typeof(T));
    }
    Type[] GetTypesForInterfaces(Type T)
    {
    	Type[] result = new Type[0];
    	var obj = Activator.CreateInstance(T);
    
    	// get the type for all interface properties that are not marked as "XmlIgnore"
    	Type[] types = T.GetProperties()
    		.Where(p => p.PropertyType.IsInterface && 
    			!p.GetCustomAttributes(typeof(System.Xml.Serialization.XmlIgnoreAttribute), false).Any())
    		.Select(p => p.GetValue(obj, null).GetType())
    		.ToArray();
    
    	result = result.ToList().Concat(types.ToList()).ToArray();
    
    	// do the same for each of the types identified
    	foreach (Type t in types)
    	{
    		Type[] embeddedTypes = GetTypesForInterfaces(t);
    		result = result.ToList().Concat(embeddedTypes.ToList()).ToArray();
    	}
    	return result;
    }
