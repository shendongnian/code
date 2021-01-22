    XDocument newDoc = new XDocument(new XElement("step"));
    foreach (XElement child in doc.Root.Elements())
    {
        XElement entry = new XElement("Test");
        entry.SetAttributeValue("Name", child.Attribute("ChildName")
                                             .Value.Replace("AdditionalSibling_", ""));
    
        if (child.Elements("AdditionalSiblings").Count() > 0)
        {
            entry.SetAttributeValue("AdditionalSibling",
                child.Elements("AdditionalSiblings").Elements()
                                                    .Select(xe => xe.Attribute("SiblingName").Value)
                                                    .Aggregate((s1,s2) => s1+","+s2));
        }
        else
        {
            entry.SetAttributeValue("AdditionalSibling", "");
        }
        newDoc.Root.Add(entry);
    
    }
    
