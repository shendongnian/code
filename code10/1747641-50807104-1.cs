    public class SerBinder : ISerializationBinder
    {
        public IList<Type> G_KnownTypes;
        public SerBinder()
        {
            G_KnownTypes = new List<Type>();
            G_KnownTypes.Add(typeof(ArticleType));
            G_KnownTypes.Add(typeof(ArtTypeBall));
            G_KnownTypes.Add(typeof(ArtTypeLamp));
            G_KnownTypes.Add(typeof(Stock));
            G_KnownTypes.Add(typeof(StockObject));
            G_KnownTypes.Add(typeof(Order));
            G_KnownTypes.Add(typeof(Position));
            G_KnownTypes.Add(typeof(Place));
        }
        public Type BindToType(string assemblyName, string typeName)
        {
            return G_KnownTypes.SingleOrDefault(t => t.Name == typeName);
        }
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }
    }
