    public string ExportCsv<T>(IEnumerable<T> items, Dictionary<string, string> headers)
    {
        string result;
        using (TextWriter textWriter = new StreamWriter(myStream, myEncoding))
        {
            result = this.WriteDataAsCsvWriter<T>(items, textWriter, headers);
        }
        return result;
    }
    private string WriteDataAsCsvWriter<T>(IEnumerable<T> items, TextWriter textWriter, Dictionary<string, string> headers)
    {
        //Add null validation
        ////print the columns headers
        StringBuilder sb = new StringBuilder();
        //Headers
        foreach (KeyValuePair<string, string> kvp in headers)
        {
            sb.Append(ToCsv(kvp.Value));
            sb.Append(",");
        }
        sb.Remove(sb.Length - 1, 1);//the last ','
        sb.Append(Environment.NewLine);
        //the values
        foreach (var item in items)
        {
            try
            {
                Dictionary<string, string> values = GetPropertiesValues(item, headers);
                foreach (var value in values)
                {
                    sb.Append(ToCsv(value.Value));
                    sb.Append(",");
                }
                sb.Remove(sb.Length - 1, 1);//the last ','
                sb.Append(Environment.NewLine);
            }
            catch (Exception e1)
            {
                 //do something
            }
        }
        textWriter.Write(sb.ToString());
        return sb.ToString();
    }
    //Help function that encode text to csv:
    public static string ToCsv(string input)
    {
        if (input != null)
        {
            input = input.Replace("\r\n", string.Empty)
                .Replace("\r", string.Empty)
                .Replace("\n", string.Empty);
            if (input.Contains("\""))
            {
                input = input.Replace("\"", "\"\"");
            }
            input = "\"" + input + "\"";
        }
        return input;
    }
