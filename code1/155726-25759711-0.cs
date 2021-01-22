	var serializer = new XmlSerializer(type);
	string xmlString;
	using (var writer = new StringWriter())
	{
		serializer.Serialize(writer, objectData, sn); // OutOfMemoryException here
		xmlString = writer.ToString();
	}
