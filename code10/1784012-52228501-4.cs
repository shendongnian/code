    [StructLayout(LayoutKind.Sequential)]
    struct SCROLLINFO {
        public int cbSize;
        public ScrollInfoMask fMask;
        public int nMin;
        public int nMax;
        public uint nPage;
        public int nPos;
        public int nTrackPos;
    }
    public enum ScrollInfoMask : uint {
        SIF_RANGE = 0x1,
        SIF_PAGE = 0x2,
        SIF_POS = 0x4,
        SIF_DISABLENOSCROLL = 0x8,
        SIF_TRACKPOS = 0x10,
        SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS),
    }
    [DllImport("user32.dll")]
    private static extern bool GetScrollInfo(IntPtr hwnd, SBOrientation fnBar, 
        ref SCROLLINFO lpsi);
    public enum SBOrientation : int { SB_HORZ = 0x0, SB_VERT = 0x1 }
    private void richTextBox1_VScroll(object sender, EventArgs e)
    {
        var info = new SCROLLINFO() { 
            cbSize = (Marshal.SizeOf<SCROLLINFO>()),
            fMask = ScrollInfoMask.SIF_ALL 
        };
        GetScrollInfo(richTextBox1.Handle, SBOrientation.SB_VERT, ref info);
        if (info.nPage + info.nPos == info.nMax)
        {
            //VScroll is at bottom
        }
    }
