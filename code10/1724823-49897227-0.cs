    public static T Deserialize<T>(this XDocument xdoc)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
    
        using (StringReader reader = new StringReader(xdoc.ToString()))
        {
            T cfg = (T) serializer.Deserialize(reader);
            return cfg;
        }
    }
