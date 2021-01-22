        public static string SerializeObject<T>(T o)
        {
            string serializeObject = string.Empty;
            if (o != null)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(T));
                        xs.Serialize(ms, o);
                        using (System.IO.StreamReader sr = new StreamReader(ms))
                        {
                            serializeObject = sr.CurrentEncoding.GetString(ms.ToArray());
                        }
                    }
                }
                catch { }
            }
            return serializeObject;
        }
