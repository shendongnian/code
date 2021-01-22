    public static class Serialization
    {
        public static void Serialize(object o, Stream output)
        {
            var serializer = new XmlSerializer(o.GetType());
            serializer.Serialize(output, o);
        }
    }
