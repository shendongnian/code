    public static string serializeListtoXML<T>(T obj)
    {
        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
        {
            serializer.Serialize(ms, obj);
            ms.Position = 0;
            xmlDoc.Load(ms);
            return xmlDoc.InnerXml;
        }
    }
