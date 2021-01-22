    string outputString;
    using (StringReader reader = new StringReader(originalString)
    using (StringWriter writer = new StringWriter())
    {
        string line;
        while((line = reader.ReadLine()) != null)
        {
            if (line.Trim().Length > 0)
                writer.WriteLine(line);
        }
        outputString = writer.ToString();
    }
