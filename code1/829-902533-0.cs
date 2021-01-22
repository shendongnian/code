    public static string Concat(params string[] values)
    {
        int totalLength = 0;
        if (values == null)
        {
            throw new ArgumentNullException("values");
        }
        string[] strArray = new string[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            string str = values[i];
            strArray[i] = (str == null) ? Empty : str;
            totalLength += strArray[i].Length;
            if (totalLength < 0)
            {
                throw new OutOfMemoryException();
            }
        }
        return ConcatArray(strArray, totalLength);
    }
    
    public static string Concat(string str0, string str1, string str2, string str3)
    {
        if (((str0 == null) && (str1 == null)) && ((str2 == null) && (str3 == null)))
        {
            return Empty;
        }
        if (str0 == null)
        {
            str0 = Empty;
        }
        if (str1 == null)
        {
            str1 = Empty;
        }
        if (str2 == null)
        {
            str2 = Empty;
        }
        if (str3 == null)
        {
            str3 = Empty;
        }
        int length = ((str0.Length + str1.Length) + str2.Length) + str3.Length;
        string dest = FastAllocateString(length);
        FillStringChecked(dest, 0, str0);
        FillStringChecked(dest, str0.Length, str1);
        FillStringChecked(dest, str0.Length + str1.Length, str2);
        FillStringChecked(dest, (str0.Length + str1.Length) + str2.Length, str3);
        return dest;
    }
    
    private static string ConcatArray(string[] values, int totalLength)
    {
        string dest = FastAllocateString(totalLength);
        int destPos = 0;
        for (int i = 0; i < values.Length; i++)
        {
            FillStringChecked(dest, destPos, values[i]);
            destPos += values[i].Length;
        }
        return dest;
    }
    
    private static unsafe void FillStringChecked(string dest, int destPos, string src)
    {
        int length = src.Length;
        if (length > (dest.Length - destPos))
        {
            throw new IndexOutOfRangeException();
        }
        fixed (char* chRef = &dest.m_firstChar)
        {
            fixed (char* chRef2 = &src.m_firstChar)
            {
                wstrcpy(chRef + destPos, chRef2, length);
            }
        }
    }
 
