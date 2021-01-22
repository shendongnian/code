    private T DeserializeObject<T>(XmlDocument xDoc, string typeName)
    {
        Type type = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Single(t => t.FullName == typeName);
        object o;
        var serializer = new XmlSerializer(typeof(T));
        using (TextReader tr = new StringReader(xDoc.InnerXml))
        {
            o = serializer.Deserialize(tr);
            tr.Close();
        }
        return (T)o;
    }
