    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication
    {
    
      class Program
      {
    
            public enum RESOURCE_SCOPE_NET
            {
            RESOURCE_CONNECTED  = 0x00000001,
            RESOURCE_GLOBALNET  = 0x00000002,
            RESOURCE_REMEMBERED = 0x00000003,
            RESOURCE_RECENT     = 0x00000004,
            RESOURCE_CONTEXT    = 0x00000005
            }
    
            public enum RESOURCE_TYPE_NET
            {
            RESOURCETYPE_ANY      = 0x00000000,
            RESOURCETYPE_DISK     = 0x00000001,
            RESOURCETYPE_PRINT    = 0x00000002,
            RESOURCETYPE_RESERVED = 0x00000008,
            }
    
            public enum RESOURCE_USAGE_NET
            {
            RESOURCEUSAGE_CONNECTABLE   =0x00000001,
            RESOURCEUSAGE_CONTAINER     =0x00000002,
            RESOURCEUSAGE_NOLOCALDEVICE =0x00000004,
            RESOURCEUSAGE_SIBLING       =0x00000008,
            RESOURCEUSAGE_ATTACHED      =0x00000010,
            RESOURCEUSAGE_ALL           =(RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),
            }
    
            public enum RESOURCE_DISPLAYTYPE_NET
            {
              RESOURCEDISPLAYTYPE_GENERIC = 0x00000000,
              RESOURCEDISPLAYTYPE_DOMAIN  = 0x00000001,
              RESOURCEDISPLAYTYPE_SERVER  = 0x00000002,
              RESOURCEDISPLAYTYPE_SHARE   = 0x00000003,
              RESOURCEDISPLAYTYPE_FILE    = 0x00000004,
              RESOURCEDISPLAYTYPE_GROUP   = 0x00000005,
              RESOURCEDISPLAYTYPE_NETWORK = 0x00000006,
              RESOURCEDISPLAYTYPE_ROOT    = 0x00000007,
              RESOURCEDISPLAYTYPE_SHAREADMIN   = 0x00000008,
              RESOURCEDISPLAYTYPE_DIRECTORY    = 0x00000009,
              RESOURCEDISPLAYTYPE_TREE         = 0x0000000A,
              RESOURCEDISPLAYTYPE_NDSCONTAINER = 0x0000000B
            }     
        
            [DllImport("mpr.dll", CharSet=CharSet.Auto)]
            public static extern int WNetEnumResource(
            IntPtr   hEnum,
            ref int  lpcCount,
            IntPtr   lpBuffer,
            ref int  lpBufferSize );
    
            [DllImport("mpr.dll", CharSet=CharSet.Auto)]
            public static extern int WNetOpenEnum( RESOURCE_SCOPE_NET dwScope, RESOURCE_TYPE_NET dwType,  RESOURCE_USAGE_NET dwUsage,  [MarshalAs(UnmanagedType.AsAny)][In] Object lpNetResource,  out IntPtr lphEnum);
            [DllImport("mpr.dll", CharSet=CharSet.Auto)]
            public static extern int WNetCloseEnum( IntPtr hEnum );
    
    
    
            public struct NETRESOURCE
            {
              public RESOURCE_SCOPE_NET dwScope;
              public RESOURCE_TYPE_NET dwType;
              public RESOURCE_DISPLAYTYPE_NET dwDisplayType;
              public RESOURCE_USAGE_NET dwUsage;
              [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
              public string lpLocalName;
              [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
              public string lpRemoteName;
              [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
              public string lpComment;
              [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
              public string lpProvider;
    
            }
    
    
            private static void InitScan(Object Dummy)
    
            {
            int iRet;
            IntPtr ptrHandle = new IntPtr();
            try
    
            {
              iRet = WNetOpenEnum(RESOURCE_SCOPE_NET.RESOURCE_GLOBALNET, RESOURCE_TYPE_NET.RESOURCETYPE_ANY, RESOURCE_USAGE_NET.RESOURCEUSAGE_ALL, Dummy, out ptrHandle);
    
            if( iRet != 0 )
            {
            return;
            }
    
            int entries;
            int buffer = 16384;
            IntPtr ptrBuffer = Marshal.AllocHGlobal( buffer );
            NETRESOURCE nr;
    
            for(;;)
            {
            entries = -1;
            buffer = 16384;
            iRet =WNetEnumResource( ptrHandle, ref entries, ptrBuffer, ref buffer );
    
            if( (iRet != 0) || (entries < 1) )
            {
            break;
            }
    
            Int32 ptr = ptrBuffer.ToInt32();
            for( int i = 0; i < entries; i++ )
            {
            nr = (NETRESOURCE)Marshal.PtrToStructure( new IntPtr(ptr), typeof(NETRESOURCE) );
            if(RESOURCE_USAGE_NET.RESOURCEUSAGE_CONTAINER == (nr.dwUsage & RESOURCE_USAGE_NET.RESOURCEUSAGE_CONTAINER))
    
            {
              InitScan(nr);
            }
    
            ptr += Marshal.SizeOf( nr );
            Console.WriteLine(" {0} : LocalName='{1}' RemoteName='{2}' Description='{3}' Provider='{4}'", nr.dwDisplayType.ToString(), nr.lpLocalName, nr.lpRemoteName,nr.lpComment,nr.lpProvider );
            }
    
            }
    
            Marshal.FreeHGlobal( ptrBuffer );
            iRet =WNetCloseEnum( ptrHandle );
            }
    
            catch(Exception e)
    
            {
              Console.WriteLine("Error ** "+e.Message+" ** Trace "+e.StackTrace);
            }
    
            }
    
    
        static void Main(string[] args)
        {
          Console.WriteLine("Scannig Network....Wait a moment , be patient please ;)");
          InitScan(null);
          Console.WriteLine("Scan Network Finished");
          Console.Read();
        }
      }
    }
