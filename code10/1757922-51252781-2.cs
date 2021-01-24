    public static string[] IntPtrToStringArrayAnsi(IntPtr ptr)
    {
        var lst = new List<string>();
        do
        {
            lst.Add(Marshal.PtrToStringAnsi(ptr));
            while (Marshal.ReadByte(ptr) != 0)
            {
                ptr = IntPtr.Add(ptr, 1);
            }
            ptr = IntPtr.Add(ptr, 1);
        }
        while (Marshal.ReadByte(ptr) != 0);
        // See comment of @zneak
        if (lst.Count == 1 && lst[0] == string.Empty)
        {
            return new string[0];
        }
        return lst.ToArray();
    }
