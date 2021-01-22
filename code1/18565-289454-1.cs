        string xml = @"<foo xmlns:sys=""foobar""><bar/><bar><sys:customtag sys:sid=""1"" sys:type=""Processtart"" />
    <sys:tag>value</sys:tag>
    here are some other tags
    <sys:tag>value</sys:tag>
    <sys:customtag sys:sid=""1"" sys:type=""Procesend"" /></bar><bar/></foo>";
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
