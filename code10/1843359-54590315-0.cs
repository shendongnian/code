    class MyCustomBinder : SerializationBinder
    {
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            // TODO: turn a Type into a pair of strings
        }
        public override Type BindToType(string assemblyName, string typeName)
        {
            // TODO: turn a pair of strings into a Type
        }
    }
