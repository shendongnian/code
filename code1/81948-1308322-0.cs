        XDocument d = new XDocument();
        XNamespace xsi = "uriaddress";
        d.Add(
            new XElement(
                "element",
                new XAttribute(XNamespace.Xmlns + "xsi", "uriaddress"),
                new XAttribute("type", "foo"),
                new XAttribute(xsi + "type", "bar")));
        using (XmlWriter xw = XmlWriter.Create(Console.Out))
        {
            d.WriteTo(xw);
        }
        d.Element("element").SetAttributeValue("type", "baz");
        using (XmlWriter xw = XmlWriter.Create(Console.Out))
        {
            d.WriteTo(xw);
        }
        d.Element("element").SetAttributeValue(xsi + "type", "bar");        
        using (XmlWriter xw = XmlWriter.Create(Console.Out))
        {
            d.WriteTo(xw);
        }
