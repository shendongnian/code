    [DllImport(
            "msvcrt.dll",
            EntryPoint = "memcpy",
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = false)]
    private static extern unsafe void* UnsafeMemoryCopy(
        void* destination,
        void* source,
        uint count);
    public static byte[] GetUnderlyingBytes(string source)
    {
        var length = source.Length * sizeof(char);
        var result = new byte[length];
        unsafe
        {
            fixed (char* firstSourceChar = source)
            fixed (byte* firstDestination = result)
            {
                var firstSource = (byte*)firstSourceChar;
                UnsafeMemoryCopy(
                    firstDestination,
                    firstSource,
                    (uint)length);
            }
        }
        return result;
    }
