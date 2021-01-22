    private static string ByteArrayToHex(byte[] barray)
    {
        char[] c = new char[barray.Length * 2];
        byte b;
        for (int i = 0; i < barray.Length; ++i)
        {
            b = ((byte)(barray[i] >> 4));
            c[i * 2] = (char)(b > 9 ? b + 0x37 : b + 0x30);
            b = ((byte)(barray[i] & 0xF));
            c[i * 2 + 1] = (char)(b > 9 ? b + 0x37 : b + 0x30);
        }
        return new string(c);
    }
