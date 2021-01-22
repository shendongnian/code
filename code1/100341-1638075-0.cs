    using System.Runtime.InteropServices;
    ...
            public static bool SetRtbFace(RichTextBox rtb, Font font, bool selectionOnly) {
                CHARFORMATW fmt = new CHARFORMATW();
                fmt.cbSize = Marshal.SizeOf(fmt);
                fmt.szFaceName = font.FontFamily.Name;
                fmt.dwMask = 0x20000000;  // CFM_FACE
                return IntPtr.Zero != SendMessage(rtb.Handle, 0x444, (IntPtr)(selectionOnly ? 1 : 4), fmt);
            }
            [StructLayout(LayoutKind.Sequential, Pack = 4)]
            private class CHARFORMATW {
                public int cbSize;
                public int dwMask;
                public int dwEffects;
                public int yHeight;
                public int yOffset;
                public int crTextColor;
                public byte bCharSet;
                public byte bPitchAndFamily;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x40)]
                public string szFaceName;
            }
    
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, CHARFORMATW lParam);
