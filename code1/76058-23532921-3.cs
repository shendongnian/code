    using System.Runtime.InteropServices;
    public class Win32
    {       
        [StructLayout(LayoutKind.Sequential)]
        public struct SIZE
        {
            public int cx;
            public int cy;
        }
        [DllImport("Gdi32.dll")]
        public static extern bool GetTextExtentPoint32(IntPtr hdc, string lpString, int cbString, out SIZE lpSize);
        [DllImport("Gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
    }
