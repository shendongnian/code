    public static T GetBodyWithXmlSerializer<T>(this Message msg)
    {
        var ser = new XmlSerializer(typeof(T));
        T o;
        using (var reader = msg.GetReaderAtBodyContents())
        {
            o = (T)ser.Deserialize(reader);
        }
        return o;
    }
