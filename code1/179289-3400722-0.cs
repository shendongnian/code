    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    public class Test
    {    
        [DllImport("shlwapi.dll")]
        static extern void StrFormatByteSize64(ulong qdw, StringBuilder builder,
                                               uint cchBuf);
    
        static void Main()
        {
            ulong size = 2000;
            StringBuilder builder = new StringBuilder(128);
            StrFormatByteSize64(size, builder, 128);
            Console.WriteLine(builder);
        }
    }
