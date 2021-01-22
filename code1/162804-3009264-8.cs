        public static string ToXml<T>(T obj)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            using (Stream stream = new MemoryStream())
            using (XmlWriter writer = XmlWriter.Create(stream, settings))
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
