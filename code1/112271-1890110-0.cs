    XNamespace ns = "http://www.namespace.com/ns";
    XDocument doc = XDocument.Load(...);
    string result = doc.Element("XMLDocument")
                       .Element(ns + "collectionProperties")
                       .Elements(ns + "propertyGroup")
                       .Aggregate(new StringBuilder(),
                                  (sb, g) => g.Elements(ns + "property")
                                              .Aggregate(sb.Append("[")
                                                           .Append((string)g.Attribute("name"))
                                                           .AppendLine("]"),
                                                         (sb1, p) => sb1.Append((string)p.Attribute("key"))
                                                                        .Append("=")
                                                                        .AppendLine((string)p.Attribute("value"))))
                       .ToString();
