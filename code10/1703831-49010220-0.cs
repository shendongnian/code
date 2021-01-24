    [ComVisible(true)]
    //[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public class RFIDInterface
    {
        //[MarshalAs(UnmanagedType.Bool)]
        public bool TagDetected;
        {
            // No attribute, default access
            get;
            [SecurityPermissionAttribute(SecurityAction.Deny, UnmanagedCode = true)] 
            private set;
        }
        [MarshalAs(UnmanagedType.BStr)]
        public string TagData;
    }
