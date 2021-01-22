    public static string Serialize<T>(T item) where T:class
    {
        try
        {
            XmlSerializer serial = new XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            serial.Serialize(writer, item);
            writer.Close();
            return sb.ToString();
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Failed to serialize object of type " + typeof(T).FullName + ": " + ex.Message);
            return "Failed to serialize";
        }
    }
