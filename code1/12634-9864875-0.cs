    protected override void WndProc(ref Message m)
    {
        switch (m.Msg) {
            // WM_REFLECT is added because WM_NOTIFY is normally sent just
            // to the parent window, but Windows.Form will reflect it back
            // to us, MFC-style.
            case Win32.WM_REFLECT + Win32.WM_NOTIFY: {
                Win32.NMHDR nmhdr = (Win32.NMHDR)m.GetLParam(typeof(Win32.NMHDR));
                switch((int)nmhdr.code) {
                    case Win32.NM_CUSTOMDRAW:
                        base.WndProc(ref m);
                        Win32.NMTVCUSTOMDRAW nmTvDraw = (Win32.NMTVCUSTOMDRAW)m.GetLParam(typeof(Win32.NMTVCUSTOMDRAW));
                        switch (nmTvDraw.nmcd.dwDrawStage) {
                            case Win32.CDDS_ITEMPREPAINT:
                                // Find the node being painted.
                                TreeNode n = TreeNode.FromHandle(this, nmTvDraw.nmcd.lItemlParam);
                                if (allSelected.Contains(n))
                                    // Override its background colour.
                                    nmTvDraw.clrTextBk = ColorTranslator.ToWin32(SystemColors.Highlight);
                                m.Result = (IntPtr)Win32.CDRF_DODEFAULT;  // Continue rest of painting as normal
                                break;
                        }
                        Marshal.StructureToPtr(nmTvDraw, m.LParam, false);  // copy changes back
                        return;
                }
                break;
            }
        }
        base.WndProc(ref m);
    }
    // WM_NOTIFY notification message header.
    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public class NMHDR
    {
        private IntPtr hwndFrom;
        public IntPtr idFrom;
        public uint code;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct NMCUSTOMDRAW
    {
        public NMHDR hdr;
        public int dwDrawStage;
        public IntPtr hdc;
        public RECT rc;
        public IntPtr dwItemSpec;
        public int uItemState;
        public IntPtr lItemlParam;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVCUSTOMDRAW
    {
        public NMCUSTOMDRAW nmcd;
        public int clrText;
        public int clrTextBk;
        public int iLevel;
    }
    public const int CDIS_SELECTED = 0x0001;
    public const int CDIS_FOCUS = 0x0010;
    public const int CDDS_PREPAINT = 0x00000001;
    public const int CDDS_POSTPAINT = 0x00000002;
    public const int CDDS_PREERASE = 0x00000003;
    public const int CDDS_POSTERASE = 0x00000004;
    public const int CDDS_ITEM = 0x00010000;  // item specific 
    public const int CDDS_ITEMPREPAINT = (CDDS_ITEM | CDDS_PREPAINT);
    public const int CDDS_ITEMPOSTPAINT = (CDDS_ITEM | CDDS_POSTPAINT);
    public const int CDDS_ITEMPREERASE = (CDDS_ITEM | CDDS_PREERASE);
    public const int CDDS_ITEMPOSTERASE = (CDDS_ITEM | CDDS_POSTERASE);
    public const int CDDS_SUBITEM = 0x00020000;
    public const int CDRF_DODEFAULT = 0x00000000;
    public const int CDRF_NOTIFYITEMDRAW = 0x00000020;
    public const int CDRF_NOTIFYSUBITEMDRAW = 0x00000020;  // flags are the same, we can distinguish by context
    public const int WM_USER = 0x0400;
    public const int WM_NOTIFY = 0x4E;
    public const int WM_REFLECT = WM_USER + 0x1C00;
