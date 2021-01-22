    using System.Xml.Linq;
    foreach (XElement ele in xDoc.Root.Descendants("Result"))
    {
        CollectedUris.Add(ele.Element("Url").Value);
    }
