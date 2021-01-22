    public static bool DeepEquals(object o1, object o2)
    {
        var b1 = MessagePackSerializer.Serialize(o1, ContractlessStandardResolver.Instance);
        var b2 = MessagePackSerializer.Serialize(o2, ContractlessStandardResolver.Instance);
        return b1.SequenceEqual(b2);
    }
