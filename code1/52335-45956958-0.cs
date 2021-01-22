    var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\App_Data"));
    var directoryInfo = new DirectoryInfo(path);
    var fileInfos = directoryInfo.GetFiles("*.xml");
    foreach (var fileInfo in fileInfos)
    {
	    XmlDocument doc = new XmlDocument();
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ConformanceLevel = ConformanceLevel.Fragment;
        using (XmlReader reader = XmlReader.Create(fileInfo.FullName, settings))
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    var node = doc.ReadNode(reader);
                    string json = JsonConvert.SerializeXmlNode(node);
                }
            }
        }
    }
