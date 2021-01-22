    public partial class NativeMethods {
        
        /// Return Type: BOOL->int
        ///fBlockIt: BOOL->int
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint="BlockInput")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
    public static extern  bool BlockInput([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool fBlockIt) ;
    
    }
    
    public static void BlockInput(TimeSpan span) {
      try { 
        NativeMethods.BlockInput(true);
        Thread.Sleep(span);
      } finally {
        NativeMethods.BlockInput(false);
      }
    }
