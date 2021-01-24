    public static void Main()
    {
    	var s = XmlSerialize(new SerializeMe
    	{
    		A = 1,
    		B = 3,
    		MyClass = new MyClass { Z = 2 },
    	});
    	Console.WriteLine(s);
    }
    
    public static string XmlSerialize(object entity)
    {
    	var buf = new StringBuilder();
    	using (var writer = XmlWriter.Create(buf, new XmlWriterSettings() {
    		OmitXmlDeclaration = true,
    		Indent = true
    	}))
    	{		
    		WriteElement(writer, entity);
    	}
    	
    	return buf.ToString();
    }
    
    static void WriteElement(XmlWriter writer, object obj)
    {
    	writer.WriteStartElement(obj.GetType().Name);		
    	WriteElementProperties(writer, obj);
    	writer.WriteEndElement();
    }
    
    static void WriteElementProperties(XmlWriter writer, object obj)
    {
    	foreach (var prop in obj.GetType().GetProperties())
    	{
    		var val = prop.GetValue(obj);
    		if (val != null)
    		{
    			if (prop.PropertyType.IsValueType ||
    				prop.PropertyType.IsGenericType &&
    				prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
    			{
    				writer.WriteElementString(prop.Name, val.ToString());
    			}
    			else
    			{
    				if (prop.PropertyType.GetCustomAttribute(typeof(Nested)) != null)
    				{
    					WriteElementProperties(writer, val);
    				} else {
    					WriteElement(writer, val);
    				}
    			}
    		}
    	}
    }
