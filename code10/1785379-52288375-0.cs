    using System.Xml.Linq;
    XDocument xDoc = XDocument.Parse(xml); //xml is the string you pasted
    XNamespace tns = "http://someurl";
    var eventItems = xDoc.Element(tns + "Event").Element(tns + "EventItems").Elements(tns + "EventItem");
    foreach (var eventItem in eventItems)
    {
        Console.WriteLine(eventItem.Element(tns + "Short.Description").Value);
        Console.WriteLine(eventItem.Element(tns + "Detailed.Description").Value);
    }
