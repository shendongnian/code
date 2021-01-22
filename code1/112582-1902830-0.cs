        [DllImport("MPR.dll", CharSet = CharSet.Auto)]
        static extern int WNetEnumResource(IntPtr hEnum, ref int lpcCount, IntPtr lpBuffer, ref int lpBufferSize);
        [DllImport("MPR.dll", CharSet = CharSet.Auto)]
        static extern int WNetOpenEnum(RESOURCE_SCOPE dwScope, RESOURCE_TYPE dwType, RESOURCE_USAGE dwUsage,
            [MarshalAs(UnmanagedType.AsAny)][In] object lpNetResource, out IntPtr lphEnum);
        [DllImport("MPR.dll", CharSet = CharSet.Auto)]
        static extern int WNetCloseEnum(IntPtr hEnum);
        public enum RESOURCE_SCOPE : uint
        {
            RESOURCE_CONNECTED = 0x00000001,
            RESOURCE_GLOBALNET = 0x00000002,
            RESOURCE_REMEMBERED = 0x00000003,
            RESOURCE_RECENT = 0x00000004,
            RESOURCE_CONTEXT = 0x00000005
        }
        public enum RESOURCE_TYPE : uint
        {
            RESOURCETYPE_ANY = 0x00000000,
            RESOURCETYPE_DISK = 0x00000001,
            RESOURCETYPE_PRINT = 0x00000002,
            RESOURCETYPE_RESERVED = 0x00000008,
        }
        public enum RESOURCE_USAGE : uint
        {
            RESOURCEUSAGE_CONNECTABLE = 0x00000001,
            RESOURCEUSAGE_CONTAINER = 0x00000002,
            RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,
            RESOURCEUSAGE_SIBLING = 0x00000008,
            RESOURCEUSAGE_ATTACHED = 0x00000010,
            RESOURCEUSAGE_ALL = (RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),
        }
        public enum RESOURCE_DISPLAYTYPE : uint
        {
            RESOURCEDISPLAYTYPE_GENERIC = 0x00000000,
            RESOURCEDISPLAYTYPE_DOMAIN = 0x00000001,
            RESOURCEDISPLAYTYPE_SERVER = 0x00000002,
            RESOURCEDISPLAYTYPE_SHARE = 0x00000003,
            RESOURCEDISPLAYTYPE_FILE = 0x00000004,
            RESOURCEDISPLAYTYPE_GROUP = 0x00000005,
            RESOURCEDISPLAYTYPE_NETWORK = 0x00000006,
            RESOURCEDISPLAYTYPE_ROOT = 0x00000007,
            RESOURCEDISPLAYTYPE_SHAREADMIN = 0x00000008,
            RESOURCEDISPLAYTYPE_DIRECTORY = 0x00000009,
            RESOURCEDISPLAYTYPE_TREE = 0x0000000A,
            RESOURCEDISPLAYTYPE_NDSCONTAINER = 0x0000000B
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct NetResource
        {
            public RESOURCE_SCOPE dwScope;
            public RESOURCE_TYPE dwType;
            public RESOURCE_DISPLAYTYPE dwDisplayType;
            public RESOURCE_USAGE dwUsage;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
            public string lpLocalName;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
            public string lpRemoteName;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
            public string lpComment;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
            public string lpProvider;
        }
        static System.Collections.Generic.Dictionary<string, NetResource> WNetResource(object resource)
        {
            System.Collections.Generic.Dictionary<string, NetResource> result = new System.Collections.Generic.Dictionary<string, NetResource>();
            int iRet;
            IntPtr ptrHandle = new IntPtr();
            try
            {
                iRet = WNetOpenEnum(
                    RESOURCE_SCOPE.RESOURCE_REMEMBERED, RESOURCE_TYPE.RESOURCETYPE_DISK, RESOURCE_USAGE.RESOURCEUSAGE_ALL,
                    resource, out ptrHandle);
                if (iRet != 0)
                    return null;
                int entries = -1;
                int buffer = 16384;
                IntPtr ptrBuffer = Marshal.AllocHGlobal(buffer);
                NetResource nr;
                iRet = WNetEnumResource(ptrHandle, ref entries, ptrBuffer, ref buffer);
                while ((iRet == 0) || (entries > 0))
                {
                    Int32 ptr = ptrBuffer.ToInt32();
                    for (int i = 0; i < entries; i++)
                    {
                        nr = (NetResource)Marshal.PtrToStructure(new IntPtr(ptr), typeof(NetResource));
                        if (RESOURCE_USAGE.RESOURCEUSAGE_CONTAINER == (nr.dwUsage
                            & RESOURCE_USAGE.RESOURCEUSAGE_CONTAINER))
                        {
                            //call recursively to get all entries in a container
                            WNetResource(nr);
                        }
                        ptr += Marshal.SizeOf(nr);
                        result.Add(nr.lpLocalName, nr);
                    }
                    entries = -1;
                    buffer = 16384;
                    iRet = WNetEnumResource(ptrHandle, ref entries, ptrBuffer, ref buffer);
                }
                Marshal.FreeHGlobal(ptrBuffer);
                iRet = WNetCloseEnum(ptrHandle);
            }
            catch (Exception)
            {
            }
            return result;
        }
        public static System.Collections.Generic.Dictionary<string, NetResource> WNetResource()
        {
            return WNetResource(null);
        }
