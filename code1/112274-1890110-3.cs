    StringBuilder sb = new StringBuilder();
    foreach (var propertyGroup in doc.Element("XMLDocument")
                                     .Element(ns + "collectionProperties")
                                     .Elements(ns + "propertyGroup"))
    {
        sb.Append("[")
          .Append((string)propertyGroup.Attribute("name"))
          .AppendLine("]");
        foreach (var property in propertyGroup.Elements(ns + "property"))
        {
            sb.Append((string)property.Attribute("key"))
              .Append("=")
              .AppendLine((string)property.Attribute("value"));
        }
    }
    string result = sb.ToString();
