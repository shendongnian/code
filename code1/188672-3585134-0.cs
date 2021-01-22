        [StructLayout(LayoutKind.Sequential)]
        internal struct NetResource
        {
            public uint dwScope;
            public uint dwType;
            public uint dwDisplayType;
            public uint dwUsage;
            [MarshalAs(UnmanagedType.LPWStr, SizeConst = 64)]
            public string lpLocalName;
            [MarshalAs(UnmanagedType.LPWStr, SizeConst = 64)]
            public string lpRemoteName;
            [MarshalAs(UnmanagedType.LPWStr, SizeConst = 64)]
            public string lpComment;
            [MarshalAs(UnmanagedType.LPWStr, SizeConst = 64)]
            public string lpProvider;
        }
