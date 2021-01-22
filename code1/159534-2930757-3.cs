    using (System.IO.StringReader sr = new System.IO.StringReader(serialized))
    {
       System.Xml.XmlReaderSettings xs = new System.Xml.XmlReaderSettings();
       xs.ConformanceLevel = System.Xml.ConformanceLevel.Fragment;
       System.Xml.XmlReader xr = System.Xml.XmlTextReader.Create(sr, xs);
       xr.Read();
       string metaData = xr.ReadOuterXml();
       Console.WriteLine(metaData);
       ds = new System.Data.DataSet();
       ds.ReadXml(xr);
       ds.WriteXml(Console.Out);
    }
