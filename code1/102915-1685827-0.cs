    static unsafe Boolean Compare(byte* src, byte * compare, int size)
    {
        Boolean result = true;
        int i = 0;
        while (result && i < size)
        {
            result=result&&*(src+i)==*(compare+i);
        }
        return result;
    }
    static unsafe void Replace (byte* src, byte* newData, int size) {
        for (int i = 0; i < size; i++)
            *(src + i) = *(newData + i);   
    }
    static unsafe Boolean Swap(IntPtr ptr, byte[] search, byte[] newData, int ptrBytes)
    {
        Boolean result = false;
        byte* pSearch =  (byte*) Marshal.UnsafeAddrOfPinnedArrayElement(search, 0);
        byte* pReplace = (byte*)Marshal.UnsafeAddrOfPinnedArrayElement(newData, 0);
        for (int i = 0; i < ptrBytes - search.Length;i++ )
        {
            byte* pTarget = (byte*)ptr.ToPointer()+i;
            if (Compare(pTarget, pSearch, search.Length))
            {
                Replace(pTarget, pReplace, newData.Length);
                return true;
            }
        }
        return result;
    }
