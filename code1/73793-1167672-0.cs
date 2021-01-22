    string s = "<tagName>Data between the tag</tagName>";
    using (XmlReader xr = XmlReader.Create(new StringReader(s)))
    {
        xr.Read();
        Console.WriteLine(xr.ReadElementContentAsString());
    }
