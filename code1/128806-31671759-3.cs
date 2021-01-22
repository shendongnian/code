    public class JsonSerializerDeserializer<T> where T : class
    {
        private readonly DataContractJsonSerializer jsonSerializer;
        public JsonSerializerDeserializer()
        {
            this.jsonSerializer = new DataContractJsonSerializer(typeof(T));
        }
        public string Serialize(T t)
        {
            using (var memoryStream = new MemoryStream())
            {
                this.jsonSerializer.WriteObject(memoryStream, t);
                memoryStream.Position = 0;
                using (var sr = new StreamReader(memoryStream))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        public T Deserialize(string objectString)
        {
            using (var ms = new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes((objectString))))
            {
                return (T)this.jsonSerializer.ReadObject(ms);
            }
        }
    }
