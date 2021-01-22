    public class MyBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            if (assemblyName == "MyCustomAssemblyIdentifier")
                if (typeName == "MyCustomTypeIdentifier")
                    return typeof();
            return null;
        }
    }
