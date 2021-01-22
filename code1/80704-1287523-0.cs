    Assembly assbl = Assembly.GetAssembly(this.GetType());
    using(Stream s = assbl.GetManifestResourceStream("projectnamespace.embeddedfilename.xml"))
    {
        XmlDocument doc = new XmlDocument();
        using (StreamReader reader = new StreamReader(s))
        {
            doc.LoadXml(reader.ReadToEnd());
            reader.Close();
        }
    }
