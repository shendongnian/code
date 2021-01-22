    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    public class SerializationUtils
    {
        public static byte[] SerializeToByteArray(object request)
        {
            byte[] result;
            BinaryFormatter serializer = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream())
            {
                serializer.Serialize(memStream, request);
                result = memStream.GetBuffer();
            }
            return result;
        }
        public static T DeserializeFromByteArray<T>(byte[] buffer)
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream(buffer))
            {
                object newobj = deserializer.Deserialize(memStream);
                return (T)newobj;
            }
        }
    }
