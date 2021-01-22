    public partial class NativeConstants {
        
        /// QUE_ADDR_BUF_LENGTH -> 50
        public const int QUE_ADDR_BUF_LENGTH = 50;
        
        /// QUE_POST_BUF_LENGTH -> 11
        public const int QUE_POST_BUF_LENGTH = 11;
    }
    
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct QueSelectAddressType {
        
        /// WCHAR*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
        public string streetAddress;
        
        /// WCHAR*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
        public string city;
        
        /// WCHAR*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
        public string state;
        
        /// WCHAR*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
        public string country;
        
        /// WCHAR*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
        public string postalCode;
    }
    
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet=System.Runtime.InteropServices.CharSet.Unicode)]
    public struct QueAddressType {
        
        /// WCHAR[51]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst=51)]
        public string streetAddress;
        
        /// WCHAR[51]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst=51)]
        public string city;
        
        /// WCHAR[51]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst=51)]
        public string state;
        
        /// WCHAR[51]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst=51)]
        public string country;
        
        /// WCHAR[12]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst=12)]
        public string postalCode;
    }
