    [StructLayout(LayoutKind.Sequential)]
    struct StringRef
    {
        public IntPtr Bytes;
        public int Length;
    }
    [DllImport("CPlusPlusSide.dll")]
    private static extern int println(StringRef[] array, int count);
    public static int Println(params string[] strings)
    {
        var utf8s = Array.ConvertAll(strings, x => Encoding.UTF8.GetBytes(x));
        var handles = new GCHandle[utf8s.Length];
        var refs = new StringRef[utf8s.Length];
        try
        {
            for (int i = 0; i < handles.Length; i++)
            {
                try
                {
                }
                finally
                {
                    handles[i] = GCHandle.Alloc(utf8s[i], GCHandleType.Pinned);
                }
                refs[i] = new StringRef
                {
                    Bytes = handles[i].AddrOfPinnedObject(),
                    Length = (int)utf8s[i].Length
                };
            }
            return println(refs, refs.Length);
        }
        finally
        {
            for (int i = 0; i < handles.Length; i++)
            {
                if (handles[i].IsAllocated)
                {
                    handles[i].Free();
                }
            }
        }
    }
