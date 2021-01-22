    public static string ToXml(this object serializableObject)
    {
        var aMemStr = new MemoryStream();
        try
        {
            var serializer = new XmlSerializer(serializableObject.GetType());
            serializer.Serialize(new XmlTextWriter(aMemStr, null), serializableObject);
            return Encoding.UTF8.GetString(aMemStr.ToArray());
        }
        finally { if (aMemStr != null) { aMemStr.Dispose(); } }
    }
    string xml = dataSet.ToXml();
    public static T ToObject<T>(this string xmlString)
    {
        var aStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString));
        try { return (T)new XmlSerializer(typeof(T)).Deserialize(aStream); }
        finally { if (aStream != null) { aStream.Dispose(); aStream = null; } }
    }
    DataSet dataSet = xml.ToObject<DataSet>();
