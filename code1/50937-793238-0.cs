    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet=System.Runtime.InteropServices.CharSet.Ansi)]
    public struct T_SAMPLE_STRUCT {
        
        /// int
        public int num;
        
        /// char[20]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst=20)]
        public string text;
    }
    
    public partial class NativeMethods {
        
        /// Return Type: SAMPLE_STRUCT->T_SAMPLE_STRUCT
        ///ss: SAMPLE_STRUCT->T_SAMPLE_STRUCT
        [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="sampleFunction")]
    public static extern  T_SAMPLE_STRUCT sampleFunction(T_SAMPLE_STRUCT ss) ;
    
    }
