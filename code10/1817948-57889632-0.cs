    public class JsonManagerKnownTypesBinder : ISerializationBinder
    {
        public IList<Type> KnownTypes { get; set; }
    
        public Type BindToType(string assemblyName, string typeName)
        {
            return KnownTypes.SingleOrDefault(t => t.Name == typeName && t.Assembly.GetName().Name == assemblyName);
        }
    
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = serializedType.Assembly.GetName().Name;
            typeName = serializedType.FullName;
        }
    }
