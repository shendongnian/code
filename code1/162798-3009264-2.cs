        public string ToXml<T>(T obj)
        {
            using (Stream stream = new MemoryStream())
            using (TextWriter writer = new StreamWriter(stream))
            {
                new XmlSerializer(obj.GetType()).Serialize(writer, obj);
                writer.Flush();
                stream.Flush();
                stream.Position = 0;
                using (TextReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
