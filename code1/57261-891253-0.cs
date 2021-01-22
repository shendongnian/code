    Regex re = new Regex("^[ \t\r\n]*<");
    if (re.Match(data).Success)
    {
        try
        {
            return XElement.Parse(data).Value;
        }
        catch (System.Xml.XmlException)
        {
            return data;
        }
    }
    else
    {
        return data;
    }
