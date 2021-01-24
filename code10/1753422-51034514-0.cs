            string xmlString;
            using (var client = new WebClient())
            {
                xmlString = client.DownloadString("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            }
        var doc = XDocument.Parse(xmlString);
        XNamespace ns = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref";
        var values = doc
            .Root
            .Element(ns + "Cube")             
            .Element(ns + "Cube")
            .Elements(ns + "Cube")
            .ToDictionary(e => e.Attribute("currency"), e => (double) e.Attribute("rate"));
