    XDocument xml = System.Xml.Linq.XDocument.Parse(YOUR_XML);
    IEnumerable<XElement> records = xml.Root.Element("RECORDS").Elements();
    IEnumerable<XElement> errors = xml.Root.Element("ERRORS").Elements();
    IEnumerable<XElement> elements = from el in records.Concat(errors)
                                     orderby DateTime.Parse(el.Element("DATETIME").Value)
                                      select el;
    foreach (XElement el in elements)
    {
        // do something.
    }
