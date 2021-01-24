    public class MyBinder : ISerializationBinder
    {
        public Dictionary<string,Type> Types { get; set; }
        public Type BindToType(string assemblyName, string typeName)
        {
            // probably want to add some error handling here
            return Types[typeName];
        }
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            // not very efficient, but could have a separate reverse dictionary
            typeName= Types.First(t => t.Value == serializedType).Value;
        }
    }
    var settings = new JsonSerializerSettings { SerializationBinder = new MyBinder { ... } };
