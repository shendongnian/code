     public static string SerializeObject<T>(object o)
            {
                MemoryStream ms = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(T));
                //here is my code
                UTF8Encoding encoding = new UTF8Encoding(false);
                XmlTextWriter xtw = new XmlTextWriter(ms, encoding);
                //XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF8);
                xs.Serialize(xtw, o);
                ms = (MemoryStream)xtw.BaseStream;
                return StringHelpers.UTF8ByteArrayToString(ms.ToArray());
           }
