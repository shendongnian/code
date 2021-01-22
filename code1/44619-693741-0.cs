    public static unsafe byte GenerateCheckByte(byte[] packetArray, int length, UInt32 seed)
    {
        fixed(byte *packet = packetArray)
        {
            ... etc
        }
    }
