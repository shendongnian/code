    private void ParseXML(string url) {
        string xmlSource;
        using(WebClient wc = new WebClient())
            xmlSource = wc.DownloadString(url);
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlSource);
    }
