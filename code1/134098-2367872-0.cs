    using System.Runtime.InteropServices;
    using System;
    
    namespace TclWrap {
        public class TclAPI {
             [DllImport("tcl84.DLL")]
             public static extern IntPtr Tcl_CreateInterp();
             [DllImport("tcl84.Dll")]
             public static extern int Tcl_Eval(IntPtr interp,string skript);
             [DllImport("tcl84.Dll")]
             public static extern IntPtr Tcl_GetObjResult(IntPtr interp);
             [DllImport("tcl84.Dll")]
             public static extern string Tcl_GetStringFromObj(IntPtr tclObj,IntPtr length);
        }
        public class TclInterpreter {
            private IntPtr interp;
            public TclInterpreter() {
                interp = TclAPI.Tcl_CreateInterp();
                if (interp == IntPtr.Zero) {
                    throw new SystemException("can not initialize Tcl interpreter");
                }
            }
            public int evalScript(string script) {
                return TclAPI.Tcl_Eval(interp,script);        
            }
            public string Result {
                get { 
                    IntPtr obj = TclAPI.Tcl_GetObjResult(interp);
                    if (obj == IntPtr.Zero) {
                        return "";
                    } else {
                        return TclAPI.Tcl_GetStringFromObj(obj,IntPtr.Zero);
                    }
                }
            }
        }
    }
