    public static IList<IList<string>> Parse(string content)
    {
        IList<IList<string>> records = new List<IList<string>>();
        StringReader stringReader = new StringReader(content);
        bool inQoutedString = false;
        IList<string> record = new List<string>();
        StringBuilder fieldBuilder = new StringBuilder();
        while (stringReader.Peek() != -1)
        {
            char readChar = (char)stringReader.Read();
            if (readChar == '\n' || (readChar == '\r' && stringReader.Peek() == '\n'))
            {
                // If it's a \r\n combo consume the \n part and throw it away.
                if (readChar == '\r')
                {
                    stringReader.Read();
                }
                if (inQoutedString)
                {
                    if (readChar == '\r')
                    {
                        fieldBuilder.Append('\r');
                    }
                    fieldBuilder.Append('\n');
                }
                else
                {
                    record.Add(fieldBuilder.ToString().TrimEnd());
                    fieldBuilder = new StringBuilder();
                    records.Add(record);
                    record = new List<string>();
                    inQoutedString = false;
                }
            }
            else if (fieldBuilder.Length == 0 && !inQoutedString)
            {
                if (char.IsWhiteSpace(readChar))
                {
                    // Ignore leading whitespace
                }
                else if (readChar == '"')
                {
                    inQoutedString = true;
                }
                else if (readChar == ',')
                {
                    record.Add(fieldBuilder.ToString().TrimEnd());
                    fieldBuilder = new StringBuilder();
                }
                else
                {
                    fieldBuilder.Append(readChar);
                }
            }
            else if (readChar == ',')
            {
                if (inQoutedString)
                {
                    fieldBuilder.Append(',');
                }
                else
                {
                    record.Add(fieldBuilder.ToString().TrimEnd());
                    fieldBuilder = new StringBuilder();
                }
            }
            else if (readChar == '"')
            {
                if (inQoutedString)
                {
                    if (stringReader.Peek() == '"')
                    {
                        stringReader.Read();
                        fieldBuilder.Append('"');
                    }
                    else
                    {
                        inQoutedString = false;
                    }
                }
                else
                {
                    fieldBuilder.Append(readChar);
                }
            }
            else
            {
                fieldBuilder.Append(readChar);
            }
        }
        record.Add(fieldBuilder.ToString().TrimEnd());
        records.Add(record);
        return records;
    }
