    static public string ToNonNullString(this XmlAttribute attr)
    {
        if (attr == null)
            return string.Empty;
        return attr.Value;
    }
