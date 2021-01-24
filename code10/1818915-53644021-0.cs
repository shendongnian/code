    var xml = XDocument.Load(ConfigurationManager.AppSettings.Get("studentFile"));
    
    var query = from c in xml.Root.Descendants("Student")
                   select c.Element("Picture").Value;
    
    List<string> pictureList = new List<string>();
    foreach (string pic in query)
    {
        pictureList.Add(pic);
    }
