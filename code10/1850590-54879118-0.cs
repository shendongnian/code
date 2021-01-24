    public static class MyMethods
    {       
        public static void XMLWrite<T>(this T obj, string PathXML) where T : class, new()
        {
                if (Directory.Exists(Path.GetDirectoryName(PathXML)))
                {
                    using (FileStream stream = new FileStream(PathXML, FileMode.Create))
                    using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.Unicode))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                        xmlSerializer.Serialize(writer, obj);
                    }
                }
        }
        public static T XMLRead<T>(this string PathXML) where T : class, new()
        {
                if (File.Exists(PathXML))
                {
                    XmlSerializer xmlOkuyucu = new XmlSerializer(typeof(T));
                    using (Stream okuyucu = new FileStream((PathXML), FileMode.Open))
                    {
                        return (T)xmlOkuyucu.Deserialize(okuyucu);
                    }
                }
                return default(T);
        }
     }
