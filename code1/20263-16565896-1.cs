    public static string ByteArrayToString2(byte[] ba)
    {
        char[] c = new char[ba.Length * 2];
        for( int i = 0; i < ba.Length * 2; ++i)
        {
            byte b = (byte)((ba[i>>1] >> 4*((i&1)^1)) & 0xF);
            c[i] = (char)(55 + b + (((b-10)>>31)&-7));
        }
        return new string( c );
    }
