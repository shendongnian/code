    static bool pIdlsAreEquivalent(IntPtr pIdl1, IntPtr pIdl2)
    {
        if (pIdl1 == pIdl2) return true;
        if (pIdl1 == IntPtr.Zero || pIdl2 == IntPtr.Zero) return false;
        int pIdl1Size = GetItemIDSize(pIdl1);
        if (pIdl1Size != GetItemIDSize(pIdl2)) return false;
        byte[] byteArray1 = new byte[pIdl1Size];
        byte[] byteArray2 = new byte[pIdl1Size];
        Marshal.Copy(pIdl1, byteArray1, 0, pIdl1Size);
        Marshal.Copy(pIdl2, byteArray2, 0, pIdl1Size);
        for (int i = 0; i < pIdl1Size; i++)
        {
            if (byteArray1[i] != byteArray2[i])
                return false;
        }
        return true;
    }
    static int GetItemIdSize(IntPtr pIdl)
    {
        if (pIdl == IntPtr.Zero) return 0;
        int size = 0;
        // Next line throws AccessViolationException
        ITEMIDLIST idl = (ITEMIDLIST)Marshal.PtrToStructure(pIdl, typeof(ITEMIDLIST));
        while (idl.mkid.cb > 0)
        {
            size += idl.mkid.cb;
            pIdl = (IntPtr)((int)pIdl + idl.mkid.cb);
            idl = (ITEMIDLIST)Marshal.PtrToStructure(pIdl, typeof(ITEMIDLIST));
        }
        return size;
    }
    
    public struct ITEMIDLIST 
    {
        public SHITEMID mkid;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SHITEMID
    {
        public ushort cb; // The size of identifier, in bytes, including cb itself.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] abID; // A variable-length item identifier.
    }
