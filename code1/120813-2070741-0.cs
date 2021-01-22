    public static string SerializeObject<T>(object o)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF8))
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
