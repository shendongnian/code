    ["simpleAES.dll",
    CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    private static extern bool aes_crypter(string input, IntPtr data, ref int datalen);
    ["simpleAES.dll",
    CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    private static extern bool aes_decrypter(IntPtr data, int datalen, StringBuilder sb);
    static void Main(string[] args)
    {
        int datalen = 0;
        IntPtr data = Marshal.AllocHGlobal(4096);
        if (aes_crypter("1234", data, ref datalen))
        {
            StringBuilder sb = new StringBuilder(4096);
            aes_decrypter(data, datalen, sb);
            string recover = sb.ToString();
            Console.WriteLine(recover);
        }
        Marshal.FreeHGlobal(data);
    }
