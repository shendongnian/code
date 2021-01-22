    public static byte[] HexStringToByteArray( string s )
    {
        byte[] ab = new byte[s.Length>>1];
        for( int i = 0; i < s.Length; i++ )
        {
            int b = s[i];
            b = (b - '0') + ((('9' - b)>>31)&-7);
            ab[i>>1] |= (byte)(b << 4*((i&1)^1));
        }
        return ab;
    }
