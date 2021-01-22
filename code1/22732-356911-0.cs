    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct Info {
        
        /// int
        public int id;
        
        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string szName;
    }
    
    public partial class NativeMethods {
        
        /// Return Type: Info*
        ///id: int
        [System.Runtime.InteropServices.DllImportAttribute("InfoLookup.dll", EntryPoint="LookupInfo")]
    public static extern  System.IntPtr LookupInfo(int id) ;
    
        public static LoopInfoWrapper(int id) {
           IntPtr ptr = LookupInfo(id);
           return (Info)(Marshal.PtrToStructure(ptr, typeof(Info));
        }
    
    }
