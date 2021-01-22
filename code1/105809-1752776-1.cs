    using System;
    using System.Runtime.InteropServices;
    using System.Text; // For StringBuilder
    
    class Example
    {
        [DllImport("mylib.dll", CharSet = CharSet.Unicode)]
        public static extern int GetGroovyName(int grooovyId, ref StringBuilder sbGroovyName,  int bufSize,)
    
        static void Main()
        {
            StringBuilder sbGroovyNm = new StringBuilder(256);
            int nStatus = GetGroovyName(1, ref sbGroovyNm, 256);
            if (nStatus == 0) Console.WriteLine("Got the name for id of 1. {0}", sbGroovyNm.ToString().Trim());
            else Console.WriteLine("Fail!");
        }
    }
