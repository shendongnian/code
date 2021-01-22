    // Has to have length to be XML
    if (!string.IsNullOrEmpty(data))
    {
        // If it starts with a < after trimming then it probably is XML
        // Need to do an empty check again in case the string is all white space.
        var trimmedData = data.TrimStart();
        if (string.IsNullOrEmpty(trimmedData)
        {
           return data;
        }
        if (trimmedData[0] == '<')
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
