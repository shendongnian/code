    XDocument myXDoc = XDocument.Parse(string.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?><root>{0}<root>", yourXmlString));
    foreach (XElement hotspot in myXDoc.Root.Elements())
    {
        Console.WriteLine(string.Format("X=\"{0}\" Y=\"{1}\"", hotspot.Attribute("X").Value, hotspot.Attribute("Y").Value));
    }
