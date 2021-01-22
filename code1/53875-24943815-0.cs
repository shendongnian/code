        using System;
        using System.IO;
        using System.Runtime.InteropServices;
        using System.Text;
        public class AppInfo
        {
                [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = false)]
                private static extern int GetModuleFileName(HandleRef hModule, StringBuilder buffer, int length);
                private static HandleRef NullHandleRef = new HandleRef(null, IntPtr.Zero);
                public static string StartupPath
                {
                    get
                    {
                        StringBuilder stringBuilder = new StringBuilder(260);
                        GetModuleFileName(NullHandleRef, stringBuilder, stringBuilder.Capacity);
                        return Path.GetDirectoryName(stringBuilder.ToString());
                    }
                }
        }
