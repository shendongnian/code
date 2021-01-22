    public static bool IsSerializable(this object obj)
    {
        Type t = obj.GetType();
         return  Attribute.IsDefined(t, typeof(DataContractAttribute)) || t.IsSerializable || (obj is IXmlSerializable)
    }
