    public static String PrettyPrint(String XML)
    {
    	String Result = "";
    
    	MemoryStream MS = new MemoryStream();
    	XmlTextWriter W = new XmlTextWriter(MS, Encoding.Unicode);
    	XmlDocument D   = new XmlDocument();
    
    	try
    	{
    		// Load the XmlDocument with the XML.
    		D.LoadXml(XML);
    
    		W.Formatting = Formatting.Indented;
    
    		// Write the XML into a formatting XmlTextWriter
    		D.WriteContentTo(W);
    		W.Flush();
    		MS.Flush();
    
    		// Have to rewind the MemoryStream in order to read
    		// its contents.
    		MS.Position = 0;
    
    		// Read MemoryStream contents into a StreamReader.
    		StreamReader SR = new StreamReader(MS);
    
    		// Extract the text from the StreamReader.
    		String FormattedXML = SR.ReadToEnd();
    
    		Result = FormattedXML;
    	}
    	catch (XmlException)
    	{
    	}
    
    	MS.Close();
    	W.Close();
    
    	return Result;
    }
