        public static void Serialize<T>(T data, TextWriter writer)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(writer, data);
            }
            catch (Exception e)
            {
                throw;
            }
        }
