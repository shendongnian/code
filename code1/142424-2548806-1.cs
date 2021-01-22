    public string TransformXml(object data, string xslFileName)
    {
        XmlSerializer xs = new XmlSerializer(data.GetType());
        string xmlString;
        using (StringWriter swr = new StringWriter())
        {
            xs.Serialize(swr, data);
            xmlString = swr.ToString();
        }
        var xd = new XmlDocument();
        xd.LoadXml(xmlString);
        var xslt = new System.Xml.Xsl.XslCompiledTransform();
        xslt.Load(xslFileName);
        var stm = new MemoryStream();
        xslt.Transform(xd, null, stm);
        stm.Position = 0;
        var sr = new StreamReader(stm);
        return sr.ReadToEnd();
    }
