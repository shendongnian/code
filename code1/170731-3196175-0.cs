    private static readonly Dictionary<AliceKey.AliceKeyPaths, string> RegistryMap =
        new Dictionary<AliceKey.AliceKeyPaths, string>
    {
        { AliceKey.AliceKeyPaths.NET_CLR_DATA, @"\.NET CLR Data\" },
        { AliceKey.AliceKeyPaths.NET_CLR_NETWORKING, @"\.NET CLR Networking\" },
        // etc
    };
    public static string ToRegistryString(AliceKey.AliceKeyPaths aliceKeyPath)
    {
        string value;
        return RegistryMap.TryGetValue(aliceKeyPath, out value) ? value : "";
    }
