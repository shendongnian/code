    using System.Xml.XPath;
    ...
    String val = "\"Consumer Sales & Information\"";
    String xpath = String.Format(".//CandidatesPropertyValue[@PropertyValue= {0}]", val);
    doc.XPathSelectElements(xpath);
