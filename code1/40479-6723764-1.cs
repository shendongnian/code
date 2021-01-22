    public static int IntParseFast(string value)
    {
        int result = 0;
        int length = value.Length;
        for (int i = 0; i < length; i++)
        {
            result = 10 * result + (value[i] - 48);
        }
        return result;
    }
    
    public unsafe static int IntParseUnsafe(string value)
    {
        int result = 0;
        fixed (char* v = value)
        {
            char* str = v;
            while (*str != '\0')
            {
                result = 10 * result + (*str - 48);
                str++;
            }
        }
        return result;
    }
