    // Has to have length to be XML
    if (!string.IsNullOrEmpty(data))
    {
        // If it starts with a < then it probably is XML
        // But also cover the case where there is indeterminate whitespace before the <
        if (data[0] == '<' || data.TrimStart()[0] == '<')
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
    }
    else
    {
        return data;
    }
