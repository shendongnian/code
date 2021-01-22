    public static char[] ToCharsBitShift(int x)
    {
         char[] chars = new char[4];
         chars[0] = (char)(x & 0xFF);
         chars[1] = (char)(x >> 8 & 0xFF);
         chars[2] = (char)(x >> 16 & 0xFF);
         chars[3] = (char)(x >> 24 & 0xFF);
         return chars;
    }
