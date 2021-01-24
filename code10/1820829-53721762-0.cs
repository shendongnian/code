    using (FileStream fs = new FileStream(@"c:\temp\soap.xml", FileMode.Open))
    {
        var sr = new StreamReader(fs);
        var str = sr.ReadToEnd();
        XmlDocument document = new XmlDocument();
        document.LoadXml(str);
        XmlNamespaceManager manager = new XmlNamespaceManager(document.NameTable);
        manager.AddNamespace("soap12", "http://www.w3.org/2003/05/soap-envelope");
        manager.AddNamespace("", "http://example.org/");
        XmlNodeList xnList = document.SelectNodes("//soap12:Envelope/soap12:Body/GetCountryListResponse/GetCountryListResult", manager);
        if (xnList.Count == 0) return;
        XmlNode countryListResult = xnList[0];
        List<string> result = new List<string>();
        foreach (XmlNode childNode in countryListResult.ChildNodes)
        {
            result.Add(childNode.FirstChild.Value);
        }
    }
