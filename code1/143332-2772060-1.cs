    public sealed class Version1ToVersion2DeserializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;
            if (typeName == "OldClassName")
                typeName = "NewClassName";
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}",
                                                typeName, assemblyName));
            return typeToDeserialize;
        }
    }
