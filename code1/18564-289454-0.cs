        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNamespaceManager mgr = new XmlNamespaceManager(new NameTable());
        mgr.AddNamespace("sys", "foobar");
        var matches = doc.SelectNodes("//sys:customtag[@sys:type='Processtart']", mgr);
        foreach (XmlElement start in matches)
        {
            XmlElement end = (XmlElement) start.SelectSingleNode("following-sibling::sys:customtag[@sys:type='Procesend'][1]",mgr);
            XmlNode node = start.NextSibling;
            while (node != null && node != end)
            {
                Console.WriteLine(node.OuterXml);
                node = node.NextSibling;
            }
        }
