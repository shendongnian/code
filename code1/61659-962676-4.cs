    static bool IsMicrosoftType(Type type)
    {
        AssemblyName name = type.Assembly.GetName();
        byte[] publicKeyToken = name.GetPublicKeyToken();
        
        return publicKeyToken != null
            && publicKeyToken.Length == 8
            && publicKeyToken[0] == 0xb7
            && publicKeyToken[1] == 0x7a
            && publicKeyToken[2] == 0x5c
            && publicKeyToken[3] == 0x56
            && publicKeyToken[4] == 0x19
            && publicKeyToken[5] == 0x34
            && publicKeyToken[6] == 0xe0
            && publicKeyToken[7] == 0x89;
    }
