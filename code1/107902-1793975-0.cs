	static void validate(string filename)
	{
		XmlReaderSettings settings = new XmlReaderSettings();
		settings.ProhibitDtd = false;
		settings.ValidationType = ValidationType.DTD;
		settings.ValidationEventHandler +=
			new ValidationEventHandler(ValidationCallBack);
		settings.XmlResolver = new XhtmlUrlResolver();
		// Create the XmlReader object.
		XmlReader reader = XmlReader.Create(filename, settings);
		// Parse the file. 
		while (reader.Read()) ;
	}
	// Display any validation errors.
	private static void ValidationCallBack(object sender, ValidationEventArgs e)
	{
		Console.WriteLine("Validation Error: {0}", e.Message);
	}
