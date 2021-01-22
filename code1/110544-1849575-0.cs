    var nameAttribute = xml.Descendants("c").Select(b => b.Attribute("name"))
                                            .FirstOrDefault();
    if (nameAttribute != null)
    {
        string name = nameAttribute.Value;
    }
    else
    {
        // Whatever...
    }
