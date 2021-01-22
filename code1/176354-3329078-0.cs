    byte[] byteData = new byte[] { 0xa0, 0x14, 0x72, 0xbf, 0x72, 0x3c, 0x21 };
    Type[] types = new Type[] { typeof(int), typeof(short), typeof(sbyte) };
    object[] result = new object[types.Length];
    MemoryStream ms = new MemoryStream(byteData);
    BinaryReader reader = new BinaryReader(ms);
    for (int i = 0; i < types.Length; i++)
    {
        byte[] bytes = reader.ReadBytes(Marshal.SizeOf(types[i]));
        unsafe
        {
            fixed (byte* p = bytes)
            {
                result[i] = Marshal.PtrToStructure((IntPtr)p, types[i]);
            }
        }
    }
