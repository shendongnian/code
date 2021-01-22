    public static void Save(SerializableObject o, string filename)
    {
    	using (Stream outputStream = new FileStream(filename, FileMode.Create, FileAccess.Write))
    	{
    		if (outputStream == null)
    			throw new ArgumentNullException("Must have valid output stream");
    
    		if (outputStream.CanWrite == false)
    			throw new ArgumentException("Cannot write to output stream");
    		
    		object[] attributes;
    		attributes = o.GetType().GetCustomAttributes(typeof(NamespaceAttribute), true);    
    
    		XmlWriterSettings writerSettings = new XmlWriterSettings();                
    		writerSettings.Indent = true;
    		writerSettings.NewLineOnAttributes = true;                
    		using (XmlWriter w = XmlWriter.Create(outputStream, writerSettings))
    		{
    			DataContractSerializer s = new DataContractSerializer(o.GetType());
    
    			s.WriteStartObject(w, o);
    			foreach (NamespaceAttribute ns in attributes)                      
    				w.WriteAttributeString("xmlns", ns.Prefix, null, ns.Uri);
    
    			// content
    			s.WriteObjectContent(w, o);
    			s.WriteEndObject(w);
    		}
    	}
    }
