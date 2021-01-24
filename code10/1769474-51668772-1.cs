    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RGiesecke.DllExport;
    using System.Runtime.InteropServices;
    
    namespace cs_dcsSrv
    {
        public class Class1
        {
            public delegate void strCB(String s);
    
            [DllExport("strCallBack", CallingConvention = CallingConvention.Cdecl)]
            public static void stringCallback(strCB fct)
            {
                String str = "hello from C#";
                fct(str);
            }
        }
    }
