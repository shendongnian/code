    public class StructureMapSerializerFactory : ISerializerFactory
    {
        public ISerializer GetSerializer(string name)
        {
            return ObjectFactory.GetNamedInstance<ISerializer>(name);
        }
    }
