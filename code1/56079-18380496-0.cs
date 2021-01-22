    public static TClass Deserialize<TClass>(string xml) where TClass : class, new()
    {
    	var tClass = new TClass();
    
    	xml = RemoveTypeTagFromXml(xml);
    
    	var xmlSerializer = new XmlSerializer(typeof(TClass));
    	using (TextReader textReader = new StringReader(xml))
    	{
    		tClass = (TClass)xmlSerializer.Deserialize(textReader);
    	}
    	return tClass;
    }
    
    public static string RemoveTypeTagFromXml(string xml)
    {
    	if (!string.IsNullOrEmpty(xml) && xml.Contains("xsi:type"))
    	{
    		xml = Regex.Replace(xml, @"\s+xsi:type=""\w+""", "");
    	}
    	return xml;
    }
