	public XmlElement SerializeToXmlElement()
	{
		XmlDocument doc = new XmlDocument();
		using (XmlWriter writer = doc.CreateNavigator().AppendChild())
		{
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
			new XmlSerializer(this.GetType()).Serialize(writer, this, ns);
		}
		return doc.DocumentElement;
	}
