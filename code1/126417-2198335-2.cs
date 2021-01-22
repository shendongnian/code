    using System.Runtime.InteropServices;
    public string GetUserName3()
            {
                byte[] user = new byte[256];
                Int32[] len = new Int32[1];
                len[0] = 256;
                GetUserName(user, len);
    
                return (System.Text.Encoding.ASCII.GetString(user));
     
            }
    
    [DllImport("Advapi32.dll", EntryPoint = "GetUserName",
            ExactSpelling = false, SetLastError = true)]
            static extern bool GetUserName([MarshalAs(UnmanagedType.LPArray)] byte[] lpBuffer, [MarshalAs(UnmanagedType.LPArray)] Int32[] nSize);
