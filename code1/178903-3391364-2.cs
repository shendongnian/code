    public static class JsonHelper
    {
        public static string ToJson<T>(T instance)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var tempStream = new MemoryStream())
            {
                serializer.WriteObject(tempStream, instance);
                return Encoding.Default.GetString(tempStream.ToArray());
            }
        }
        public static T FromJson<T>(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var tempStream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                return (T)serializer.ReadObject(tempStream);
            }
        }
    }
