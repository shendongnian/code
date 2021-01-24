    public static partial class BinaryFormatterHelper
    {
        public static byte[] ToBinary<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize(stream, obj);
                return stream.ToArray();
            }
        }
    }
