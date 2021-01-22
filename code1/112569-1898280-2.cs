    public static Byte[] Serialize(Object obj, ByteOrder streamOrder)
    {
        var provider = GetProvider(obj);
        if (provider.CanSerialize(obj.GetType()))
            return provider.Serialize(obj, streamOrder);
   
        throw new ArgumentException(obj.GetType() + " is non-serialisable by the specified provider '" + provider.GetType().FullName + "'.");
    }
    private static IBinarySerializatoinProvider GetProvider(Object obj)
    {
       
        var providerAttrib = Reflector.GetAttribute<BinarySerializationProviderAttribute>(obj);
        if (providerAttrib != null)
            return CreateProvider(providerAttrib.ProviderType);
   
        return CreateProvider(typeof(SerializationProvider));
    }
