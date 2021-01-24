    public static XmlDocument ObjectToXmlDocument<T>(T obj)
    {
        XmlDocument xmldoc = new XmlDocument();
    	XmlSerializer serializer = new XmlSerializer(typeof(T));
    
        using (MemoryStream stream = new MemoryStream())
        {
    		serializer.Serialize(stream, obj);
    		
    		stream.Position = 0;
            xmldoc.Load(stream);
        }
    	
    	return xmldoc;
    }
