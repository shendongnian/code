    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    class Program {
        [DllImport("user32")]
        static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        static extern void ReleaseDC(IntPtr dc);
        static void Main(string[] args) {
            IntPtr desktop = GetDC(IntPtr.Zero);
            using (Graphics g = Graphics.FromHdc(desktop)) {
                g.FillRectangle(Brushes.Red, 0, 0, 100, 100);
            }
            ReleaseDC(desktop);
        }
    }
