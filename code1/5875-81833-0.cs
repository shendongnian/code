    public static bool IsSerializable(this object obj)
    {
        if (obj is ISerializable)
            return true;
        return Attribute.IsDefined(obj.GetType(), typeof(SerializableAttribute));
    }
