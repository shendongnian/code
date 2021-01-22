    string myXml =
       "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + Environment.NewLine +
       "<!-- This is a comment -->" + Environment.NewLine +
       "<Root><Data>Test</Data></Root>";
    System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
    xml.PreserveWhitespace = true;
    xml.LoadXml(myXml);
    var newElem = xml.CreateElement("Data");
    newElem.InnerText = "Test 2";
    xml.SelectSingleNode("/Root").AppendChild(newElem);
    System.Xml.XmlWriterSettings xws = new System.Xml.XmlWriterSettings();
    xws.Indent = true;
    using (System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(Console.Out, xws))
    {
       xml.WriteTo(xw);
    }
