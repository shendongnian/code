	Input instance = null;
	var serializer = new XmlSerializer(typeof(Input));
	using (var stringReader = new StreamReader("file.xml"))
	{
		using(var xmlReader = XmlReader.Create(stringReader))
		{
			instance = (Input)serializer.Deserialize(xmlReader);
		}
	}	
