    // Read configuration
    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    ConfigurationSection readableSection = config.GetSection("SingleTag");
    string readableSectionRawXml = readableSection.SectionInformation.GetRawXml();
    XmlDocument readableSectionRawXmlDocument = new XmlDocument();
    readableSectionRawXmlDocument.Load(new StringReader(readableSectionRawXml));
    SingleTagSectionHandler readableSectionHandler = new SingleTagSectionHandler();
    Hashtable result = (Hashtable)readableSectionHandler.Create(null, null, readableSectionRawXmlDocument.DocumentElement);
    foreach (string item in result.Keys)
    {
        Console.WriteLine("{0}\t=\t{1}", item, result[item]);
    }
    // Create similar configuration section
    Hashtable mySettings = new Hashtable();
    mySettings.Add("key1", "value1:" + DateTime.Now);
    mySettings.Add("key2", "value2:" + DateTime.Now);
    mySettings.Add("key3", "value3:" + DateTime.Now);
    mySettings.Add("keynull", null);
    mySettings.Add("key4", "value4:" + DateTime.Now);
    string rawData = string.Empty;
    XmlDocument writableSectionXmlDocument = new XmlDocument();
    XmlElement rootElement = writableSectionXmlDocument.CreateElement("CreateSingleTag");
    foreach (var item in mySettings.Keys)
    {
        if (mySettings[item] != null)
        {
            rootElement.SetAttribute(item.ToString(), mySettings[item].ToString());
        }
    }
    writableSectionXmlDocument.AppendChild(rootElement);
         
    if (config.Sections.Get("CreateSingleTag") == null)
    {
        ConfigurationSection writableSection = new DefaultSection();
        writableSection.SectionInformation.SetRawXml(writableSectionXmlDocument.OuterXml);
        config.Sections.Add("CreateSingleTag", writableSection);
    }
    else
    {
    config.Sections["CreateSingleTag"].SectionInformation.SetRawXml(writableSectionXmlDocument.OuterXml);
    }
         
    config.Save();
