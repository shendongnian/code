    XmlDocument xml = new XmlDocument();
    xml.Load(@"D:\REM\config.xml");
    foreach (XmlElement site in xml.SelectNodes("SITES/SITE"))
    {
        foreach (XmlElement error in site.SelectNodes("ERROR_COUNTER"))
        {
             Console.WriteLine(error.InnerText);
        }
        foreach (XmlElement url in site.SelectNodes("TESTS/TEST/URL"))
        {
             Console.WriteLine(url.InnerText);
        }
        ... same with LogInfo and so on
    }
