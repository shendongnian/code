    string SanitizeXml(string xml)
    {
        var buffer = new StringBuilder(xml.Length);
    
        foreach(char c in xml)
        {
            if (IsLegalXmlChar(c))
            {
                    buffer.Append(c);
            }
        }
    
        return buffer.ToString();
    }
