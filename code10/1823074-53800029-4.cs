     public class Serializer
        {
            public T Deserialize<T>(string input) where T : class
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
    
                using (StringReader stringReader = new StringReader(input))
                {
                    return (T)xmlSerializer.Deserialize(stringReader);
                }
            }
    
            public string Serialize<T>(T ObjectToSerialize)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());
                StringBuilder builder = new StringBuilder();
                using (StringWriterWithEncoding textWriter = new StringWriterWithEncoding(builder, Encoding.UTF8))
                {
                    xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                    return textWriter.ToString();
                }
            }
        }
        public class StringWriterWithEncoding : StringWriter
        {
            Encoding encoding;
    
            public StringWriterWithEncoding(StringBuilder builder, Encoding encoding)
            : base(builder)
            {
                this.encoding = encoding;
            }
    
            public override Encoding Encoding
            {
                get { return encoding; }
            }
        }
