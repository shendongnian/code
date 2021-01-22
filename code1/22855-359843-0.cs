    \[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)\]
    public struct vconfig_t {
        
        /// int
        public int Npoly;
        
        /// int
        public int N;
        
        /// Ppoint_t*
        public System.IntPtr P;
        
        /// int*
        public System.IntPtr start;
        
        /// int*
        public System.IntPtr next;
        
        /// int*
        public System.IntPtr prev;
    }
    
    \[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)\]
    public struct Ppoly_t {
        
        /// Ppoint_t*
        public System.IntPtr ps;
        
        /// int
        public int pn;
    }
    
    \[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)\]
    public struct Pxy_t {
        
        /// double
        public double x;
        
        /// double
        public double y;
    }
    
    public partial class NativeMethods {
        
        /// Return Type: vconfig_t*
        ///obstacles: Ppoly_t**
        ///n_obstacles: int
        \[System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Pobsopen")\]
    public static extern  System.IntPtr Pobsopen(ref System.IntPtr obstacles, int n_obstacles) ;
    
        
        /// Return Type: int
        ///config: vconfig_t*
        ///p0: Ppoint_t->Pxy_t
        ///poly0: int
        ///p1: Ppoint_t->Pxy_t
        ///poly1: int
        ///output_route: Ppolyline_t*
        \[System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Pobspath")\]
    public static extern  int Pobspath(ref vconfig_t config, Pxy_t p0, int poly0, Pxy_t p1, int poly1, ref Ppoly_t output_route) ;
    
        
        /// Return Type: void
        ///config: vconfig_t*
        \[System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Pobsclose")\]
    public static extern  void Pobsclose(ref vconfig_t config) ;
    
    }
