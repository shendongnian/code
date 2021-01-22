    public static byte[] SerializeObject<T>(this T obj)
    {
        Contract.Requires(typeof(T).IsSerializable);
        ...
    }
