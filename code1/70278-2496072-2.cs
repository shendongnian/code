        [DllImport( "NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
        public static extern uint NetUseAdd(
             string UncServerName,
             UInt32 Level,
             ref USE_INFO_2 Buf,
             out UInt32 ParmError
            );
        [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Unicode )]
        public struct USE_INFO_2
        {
            public string ui2_local;
            public string ui2_remote;
            public string ui2_password;
            public UInt32 ui2_status;
            public UInt32 ui2_asg_type;
            public UInt32 ui2_refcount;
            public UInt32 ui2_usecount;
            public string ui2_username;
            public string ui2_domainname;
        }
