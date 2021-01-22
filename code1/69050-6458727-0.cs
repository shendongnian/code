    public static class GenericXmlSerializer
    {
        public static string Serialize<T>(T obj, Encoding encoding)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));            
            TextWriter textWriter = new StringWriterWithEncoding(new StringBuilder(), encoding);
            serializer.Serialize(textWriter, obj);
            return textWriter.ToString();
        }
        public static T Deserialize<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextReader textReader = new StringReader(xml);
            return (T)serializer.Deserialize(textReader);
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
