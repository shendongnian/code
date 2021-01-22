    string serialized;
    using (System.IO.StringWriter sw = new System.IO.StringWriter())
    {
       string metaData = "<MetaData version=\"1.0\" date=\"" + System.Xml.XmlConvert.ToString(DateTime.Now) + "\">" +
          "<Detail>Some more details</Detail></MetaData>";
       sw.Write(metaData);
       ds.WriteXml(sw, System.Data.XmlWriteMode.WriteSchema);
       sw.Close();
       serialized = sw.ToString();
    }
