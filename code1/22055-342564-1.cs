    try
	{
		XmlTextReader xmlreader1 = new XmlTextReader("C:\\Books1.xml");
		XmlTextReader xmlreader2 = new XmlTextReader("C:\\Books2.xml");
		DataSet ds = new DataSet();
		ds.ReadXml(xmlreader1);
		DataSet ds2 = new DataSet();
		ds2.ReadXml(xmlreader2);
		ds.Merge(ds2);
		ds.WriteXml("C:\\Books.xml");
		Console.WriteLine("Completed merging XML documents");
	}
	catch (System.Exception ex)
	{
		Console.Write(ex.Message);
	}
    Console.Read();	
