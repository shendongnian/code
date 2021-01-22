    string outputString;
    using (StringReader reader = new StringReader(originalString)
    using (StringWriter writer = new StringWriter())
    {
        string line;
        while((line = reader.ReadLine()) != null)
        {
            line = line.Trim();
            if (line.Length > 0)
                writer.WriteLine(line);
        }
        outputString = writer.ToString();
    }
