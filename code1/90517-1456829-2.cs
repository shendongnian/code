    XDocument doc = XDocument.Load(@"c:\sample.xml");
    XElement events = doc.Element(XName.Get("Events"));
    events.Add(new XElement ("Event",
            new XElement("DateTime", event.DateTime),
            new XElement("EventType", event.EventType),
            new XElement("Result", event.Result),
            new XElement("Provider", event.Provider),
            new XElement("ErrorMessage", event.ErrorMessage),
            new XElement("InnerException", event.InnerException)
    ));
    doc.Save(@"c:\sample.xml");
