    public static string ByteArrayToHexViaLookup32UnsafeDirect(byte[] bytes)
    {
        var lookupP = _lookup32UnsafeP;
        var result = new string((char)0, bytes.Length * 2);
        fixed (byte* bytesP = bytes)
        fixed (char* resultP = result)
        {
            uint* resultP2 = (uint*)resultP;
            for (int i = 0; i < bytes.Length; i++)
            {
                resultP2[i] = lookupP[bytesP[i]];
            }
        }
        return result;
    }
