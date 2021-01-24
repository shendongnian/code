    foreach (XmlElement a in doc.ChildNodes)
    {
        XmlAttributeCollection atributos = a.Attributes;
        for (var i = atributos.Count - 1; i >= 0; i--)
        {
            var att = a.Attributes[i];
            if (att.Value.StartsWith("#"))
            {
                a.RemoveAttribute(att.Name);
            }
        }
    }
