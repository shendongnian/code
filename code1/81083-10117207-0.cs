    [XmlRoot]
    public class SerializeClass
    {
        public int Number {
            get;
            set;
        }
    }
    public static class SerializedClass {
        public static int Number {
            get;
            set;
        }
        public static void Serialize(Stream stream) {
            SerializeClass obj = new SerializeClass();
            obj.Number = Number;
            XmlSerializer serializer = new XmlSerializer(typeof(SerializeClass));
            serializer.Serialize(stream, obj);
        }
        public static void Deserialize(Stream stream) {
            XmlSerializer serializer = new XmlSerializer(typeof(SerializeClass));
            SerializeClass obj = (SerializeClass)serializer.Deserialize(stream);
            Number = obj.Number;
        }
    }
