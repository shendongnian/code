	public Office(XmlElement e)
	{
		var valDict = e.ChildNodes.Cast<XmlNode>().Where(n => n is XmlElement)
                       .ToDictionary(x => x.Name, x => x.InnerText);
		Name = valDict["name"];
		Id = valDict["id"];
	}
