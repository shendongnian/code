    public class MyClass
    {
        private readonly ISerializerFactory serializerFactory;
        public MyClass(ISerializerFactory serializerFactory)
        {
            if (serializerFactory == null)
                throw new ArgumentNullException("serializerFactory");
            this.serializerFactory = serializerFactory;
        }
        public string SerializeSomeData(MyData data)
        {
            ISerializer serializer = serializerFactory.GetSerializer("Json");
            return serializer.Serialize(data);
        }
    }
