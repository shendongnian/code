    [Serializable]
    class MyCustomClass : ISerializable
    {
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AssemblyName = "MyCustomAssemblyIdentifier";
            info.FullTypeName = "MyCustomTypeIdentifier";
            info.AddValue("PropertyName", "PropertyValue");
        }
    }
