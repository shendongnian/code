    public static string SerializeObject<T>(object o)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (XmlWriter xtw = XmlWriter.Create(ms))
            {
                xs.Serialize(xtw, o);
                xtw.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(ms))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
