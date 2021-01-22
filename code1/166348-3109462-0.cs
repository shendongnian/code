    public static class MySerializer
    {
        public static string Serialize<T>(T data)
        {
            using (var memoryStream = new MemoryStream())
            {
                var serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(memoryStream, data);
                memoryStream.Seek(0, SeekOrigin.Begin);
                var reader = new StreamReader(memoryStream);
                string content = reader.ReadToEnd();
                return content;
            }
        }
        public static T Deserialize<T>(string xml)
        {
            using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(xml)))
            {
                var serializer = new DataContractSerializer(typeof(T));
                T theObject = (T)serializer.ReadObject(stream);
                return theObject;
            }
        }
    }
