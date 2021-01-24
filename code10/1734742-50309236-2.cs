	void Main()
	{
		string mainFolder = "StackOverflow";
		string wholesaleFolder = "Test";
		string fileName = "xmltest.xml";
		string destinationFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), mainFolder, wholesaleFolder);
		string destinationFilePath = Path.Combine(destinationFolder, fileName);
		Directory.CreateDirectory(destinationFolder);
		XmlDocument doc = new XmlDocument();
		string oneLine = "<root></root>";
		doc.Load(new StringReader(oneLine));
		doc.Save(destinationFilePath);
	}
