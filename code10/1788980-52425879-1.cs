    List<Site> siteList = new List<Site>();
    XmlDocument xml = new XmlDocument();
    xml.Load(@"D:\REM\config.xml");
    foreach (XmlElement ndSites in xml.SelectNodes("SITES/SITE"))
    {
        siteList.ErrorCounter = ndSites.GetElementsByTagName("ERROR_COUNTER")); // Maybe int.parse ? don't have ide right now
        /** do it for all you need */
        
        
        foreach (XmlElement ndTests in ndSites.SelectNodes("TESTS/TEST"))
        {
           Test currentTest = new Test();
           /** Fill it **/
           siteList.Tests.add(currentTest);
        }
    }
