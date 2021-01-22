    public class JavaScriptSerializerDeSerializer<T>
    {
        private readonly JavaScriptSerializer serializer;
        public JavaScriptSerializerDeSerializer()
        {
            this.serializer = new JavaScriptSerializer();
        }
        public string Serialize(T t)
        {
            return this.serializer.Serialize(t);
        }
        public T Deseralize(string stringObject)
        {
            return this.serializer.Deserialize<T>(stringObject);
        }
    }
