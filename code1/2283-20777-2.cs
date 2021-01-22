    /// <summary>
    /// Removes control characters and other non-UTF-8 characters
    /// </summary>
    /// <param name="inString">The string to process</param>
    /// <returns>A string with no control characters or entities above 0x00FD</returns>
    public static string RemoveTroublesomeCharacters(string inString)
    {
        if (inString == null) return null;
        StringBuilder newString = new StringBuilder();
        char ch;
        for (int i = 0; i < inString.Length; i++)
        {
            ch = inString[i];
            // remove any characters outside the valid UTF-8 range as well as all control characters
            // except tabs and new lines
            //if ((ch < 0x00FD && ch > 0x001F) || ch == '\t' || ch == '\n' || ch == '\r')
            //if using .NET version prior to 4, use above logic
            if (XmlConvert.IsXmlChar(ch)) //this method is new in .NET 4
            {
                newString.Append(ch);
            }
        }
        return newString.ToString();
    }
