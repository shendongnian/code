    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_INTEGER
    {
        public uint LowPart;
        public int HighPart;
        public SECURITY_INTEGER(int dummy)
        {
        LowPart = 0;
        HighPart = 0;
        }
    };
    
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_HANDLE
    {
        public uint LowPart;
        public uint HighPart;
        public SECURITY_HANDLE(int dummy)
        {
        LowPart = HighPart = 0;
        }
    };
    
    
    [DllImport("secur32.dll", SetLastError=true)]
      static extern int AcquireCredentialsHandle(
        string pszPrincipal, //SEC_CHAR*
        string pszPackage, //SEC_CHAR* //"Kerberos","NTLM","Negotiative"
        int fCredentialUse,
        IntPtr PAuthenticationID,//_LUID AuthenticationID,//pvLogonID, //PLUID
        IntPtr pAuthData,//PVOID
        int pGetKeyFn, //SEC_GET_KEY_FN
        IntPtr pvGetKeyArgument, //PVOID
        ref SECURITY_HANDLE phCredential, //SecHandle //PCtxtHandle ref
        ref SECURITY_INTEGER ptsExpiry); //PTimeStamp //TimeStamp ref
