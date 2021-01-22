    [ComVisible(true), Guid("79eac9e7-baf9-11ce-8c82-00aa004ba90b"),InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInternetSession
    {
        [PreserveSig]
        int RegisterNameSpace(
            [In] IClassFactory classFactory,
            [In] ref Guid rclsid,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwzProtocol,
            [In]
                int cPatterns,
            [In, MarshalAs(UnmanagedType.LPWStr)]
                string ppwzPatterns,
            [In] int dwReserved);
        [PreserveSig]
        int UnregisterNameSpace(
            [In] IClassFactory classFactory,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszProtocol);
        int Bogus1();
        int Bogus2();
        int Bogus3();
        int Bogus4();
        int Bogus5();
    }
