    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    
    namespace Utility
    {
        public class Font
        {
            public string GetFont(bute[] [FONTASBYTEARRAY])
            {
                PrivateFontCollection fc = new PrivateFontCollection();
                IntPtr pointer = Marshal.UnsafeAddrOfPinnedArrayElement([FONTASBYTEARRAY], 0);
                fc.AddMemoryFont(pointer, Convert.ToInt32([FONTASBYTEARRAY].Length));
                System.Drawing.Font f = new System.Drawing.Font(fc.Families[0], 10);
                FontFamily ff = f.FontFamily;
                return ff.Name;
            }
        }
    }
