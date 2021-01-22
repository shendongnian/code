    public static T FromXml<T>(string xml)
    {
        XmlSerializer xmlser = new XmlSerializer(typeof(T));
        using (System.IO.StringReader sr = new System.IO.StringReader(xml))
        {
            return (T)xmlser.Deserialize(sr);
        }
    }
