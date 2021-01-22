        public static T DeserializeFromString<T>(string xml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            object o = null;
            using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(xml)))
            {
                o = ser.Deserialize(ms);
            }
            return (T)o;
        }
