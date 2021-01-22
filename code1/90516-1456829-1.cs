    XDocument doc = new XDocument(
    new XDeclaration("1.0", "utf-8", "yes"),
    new XComment("Event document"),
    new XElement("Events", 
        new XElement ("Event",
            new XElement("DateTime", event.DateTime),
            new XElement("EventType", event.EventType),
            new XElement("Result", event.Result),
            new XElement("Provider", event.Provider),
            new XElement("ErrorMessage", event.ErrorMessage),
            new XElement("InnerException", event.InnerException)
        )
     ));
    doc.Save(@"c:\sample.xml");
