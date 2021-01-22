    public static string UnsafeAsciiBytesToString(this byte[] buffer, int offset)
    {
        string result = null;
        unsafe
        {
           fixed( byte* pAscii = &buffer)
           { 
               result = new String((sbyte*)pAscii, offset, buffer.Length - offset);
           }
        }
        return result;
    }
