    using (StringReader sr = new StringReader(myString))
    using (XmlReader xr = XmlReader.Create(sr))
    {
        while (xr.Read())
        {
            if (xr.NodeType == XmlNodeType.Element && xr.Name == "foo")
            {
                Console.WriteLine(xr.ReadString());
            }
        }
    }
