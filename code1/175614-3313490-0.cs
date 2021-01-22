    public static string SerializeObject<T>(T o)
    {
        var serialized = "";
        try
        {
            using (var ms = new MemoryStream())
            {
                var xs = new XmlSerializer(typeof(T));
                xs.Serialize(ms, o);
                using (var reader = new StreamReader(ms))
                {
                    serialized = sr.CurrentEncoding.GetString(ms.ToArray());
                }
            }
        }
        catch
        {
           // bad stuff happened.
        }
        return serialized;
    }
