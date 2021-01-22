    [Serializable]
    class MyCustomClass : ISerializable
    {
        string _field;
        void MyCustomClass(SerializationInfo info, StreamingContext context)
        {
            this._field = info.GetString("PropertyName");
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AssemblyName = "MyCustomAssemblyIdentifier";
            info.FullTypeName = "MyCustomTypeIdentifier";
            info.AddValue("PropertyName", this._field);
        }
    }
