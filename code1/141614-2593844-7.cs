    public enum SerializationFormat { Json, Bson, Xml };
    public interface ISerializerFactory
    {
        ISerializer GetSerializer(SerializationFormat format);
    }
    public class StructureMapSerializerFactory : ISerializerFactory
    {
        public ISerializer GetSerializer(SerializationFormat format)
        {
            return ObjectFactory.GetNamedInstance<ISerializer>(format.ToString());
        }
    }
