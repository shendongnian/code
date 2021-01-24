    using System.Xml.Serialization;
    public class Serializer
    {       
        public T Deserialize<T>(string input) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(input))
            {
                return (T) serializer.Deserialize(reader);
            }
        }
    }
