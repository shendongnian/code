      public static XElement WithDefaultXmlNamespace(this XElement xelem, XNamespace xmlns)
        {
            XName name;
            if (xelem.Name.NamespaceName == string.Empty)
                name = xmlns + xelem.Name.LocalName;
            else
                name = xelem.Name;
           
            XElement retelement;
            if (!xelem.Elements().Any())
            {
                retelement = new XElement(name, xelem.Value);
            }
            else
             retelement= new XElement(name,
                from e in xelem.Elements()
                select e.WithDefaultXmlNamespace(xmlns));
           
            foreach (var at in xelem.Attributes())
            {
                retelement.Add(at);
            }
            return retelement;
        }
