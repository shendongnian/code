    public struct IconInfo {
        public bool fIcon;
        public int xHotspot;
        public int yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;
    }
    
    public class CursorUtil {
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr handle);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);
        // Based on the article and comments here:
        // http://www.switchonthecode.com/tutorials/csharp-tutorial-how-to-use-custom-cursors
        // Note that the returned Cursor must be disposed of after use, or you'll leak memory!
        public static Cursor CreateCursor(Bitmap bm, int xHotspot, int yHotspot) {
            IntPtr cursorPtr;
            IntPtr ptr = bm.GetHicon();
            IconInfo tmp = new IconInfo();
            GetIconInfo(ptr, ref tmp);
            tmp.xHotspot = xHotspot;
            tmp.yHotspot = yHotspot;
            tmp.fIcon = false;
            cursorPtr = CreateIconIndirect(ref tmp);
            if (tmp.hbmColor != IntPtr.Zero) DeleteObject(tmp.hbmColor);
            if (tmp.hbmMask != IntPtr.Zero) DeleteObject(tmp.hbmMask);
            if (ptr != IntPtr.Zero) DestroyIcon(ptr);
            return new Cursor(cursorPtr);
        }
        public static Bitmap AsBitmap(Control c) {
            Bitmap bm = new Bitmap(c.Width, c.Height);
            c.DrawToBitmap(bm, new Rectangle(0, 0, c.Width, c.Height));
            return bm;
        }
