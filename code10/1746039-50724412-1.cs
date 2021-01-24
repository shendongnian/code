    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg,
        uint wParam, uint lParam);
    [StructLayout(LayoutKind.Sequential)]
    struct SCROLLINFO {
        public uint cbSize;
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
    private static extern bool GetScrollInfo(IntPtr hwnd, 
        SBOrientation fnBar, ref SCROLLINFO lpsi);
    public enum SBOrientation : int {
        SB_HORZ = 0x0,
        SB_VERT = 0x1,
    }
    const uint WM_HSCROLL = 0x0114;
    const uint SB_THUMBPOSITION = 4;
