	XmlDocument doc = new XmlDocument();
	doc.Load( filename );
	doc.InsertBefore( doc.CreateDocumentType( "doc_type_name", null, DtdFilePath, null ), 
		doc.DocumentElement );
	/// <summary>
	/// Class to test a document against DTD
	/// </summary>
	/// <param name="doc">XML The document to validate</param>
	private static bool ValidateDoc( XmlDocument doc )
	{
		bool isXmlValid = true;
		StringBuilder xmlValMsg = new StringBuilder();
		StringWriter sw = new StringWriter();
		doc.Save( sw );
		doc.Save( TestFilename );
		XmlReaderSettings settings = new XmlReaderSettings();
		settings.ProhibitDtd = false;
		settings.ValidationType = ValidationType.DTD;
		settings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings;
		settings.ValidationEventHandler += new ValidationEventHandler( delegate( object sender, ValidationEventArgs args )
		{
			isXmlValid = false;
			xmlValMsg.AppendLine( args.Message );
		} );
		XmlReader validator = XmlReader.Create( new StringReader( sw.ToString() ), settings );
		while( validator.Read() )
		{
		}
		validator.Close();
		string message = xmlValMsg.ToString();
		return isXmlValid;
	}
