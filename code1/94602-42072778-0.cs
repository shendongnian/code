    public string ToXml()
    {
    	string result;
    
    	var serializer = new XmlSerializer(this.GetType());
    
    	using (var writer = new StringWriter())
    	{
    		serializer.Serialize(writer, this);
    		result = writer.ToString();
    	}
    
    	serializer = null;
    
    	// Replace all nullable fields, other solution would be to use add PropSpecified property for all properties that are not strings
    	result = Regex.Replace(result, "\\s+<\\w+ xsi:nil=\"true\" \\/>", string.Empty);
    
    	return result;
    }
