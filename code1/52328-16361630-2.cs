    public XmlDocument JsonToXML(string json)
    {
		XmlDocument doc = new XmlDocument();
		using (var reader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(json), XmlDictionaryReaderQuotas.Max))
		{
			XElement xml = XElement.Load(reader);
	    	doc.LoadXml(xml.ToString());
		}
		return doc;
	}
