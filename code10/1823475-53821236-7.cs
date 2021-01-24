	private DiagnosisErrorResponse ReadXmlFileByPath(string filePath)
	{
		using (var xmlReader = XmlReader.Create(filePath))
		{
			if (!xmlReader.ReadToDescendant("DiagnosisErrorResponse", "blabla.xsd"))
				return null;
			XmlSerializer xs = new XmlSerializer(typeof(DiagnosisErrorResponse));
			var result = (DiagnosisErrorResponse)xs.Deserialize(xmlReader);
			return result;
		}
	}		
