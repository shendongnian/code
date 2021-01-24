    List<Site> siteList = new List<Site>();
    XmlDocument xml = new XmlDocument();
    xml.Load(@"D:\REM\config.xml");
    foreach (XmlElement ndSites in xml.SelectNodes("SITES/SITE"))
    {
        siteList.ErrorCounter = int.Parse(ndSites["ERROR_COUNTER"].innerText); // You should handle the potential parse error expression
        /** do it for all you need */
        
        
        foreach (XmlElement ndTests in ndSites.SelectNodes("TESTS/TEST"))
        {
           Test currentTest = new Test();
           /** Fill it **/
           siteList.Tests.add(currentTest);
        }
    }
