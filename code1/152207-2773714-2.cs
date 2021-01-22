    public static void Deserialize<T>(out T data, XmlReader reader)
    {
        try
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            data = (T)xs.Deserialize(reader);
        }
        catch (Exception e)
        {
            reader.Close();
            throw;
        }
    }
