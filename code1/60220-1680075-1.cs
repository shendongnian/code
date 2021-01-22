    public class Listview : ListView
    {
        private bool isInWmPaintMsg=false;
        [StructLayout(LayoutKind.Sequential)]
        public struct NMHDR
        {
            public IntPtr hwndFrom;
            public IntPtr idFrom;
            public int code;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0F: // WM_PAINT
                    this.isInWmPaintMsg = true;
                    base.WndProc(ref m);
                    this.isInWmPaintMsg = false;
                    break;
                case 0x204E: // WM_REFLECT_NOTIFY
                    NMHDR nmhdr = (NMHDR)m.GetLParam(typeof(NMHDR));
                    if (nmhdr.code == -12)
                    { // NM_CUSTOMDRAW
                        if (this.isInWmPaintMsg)
                            base.WndProc(ref m);
                    }
                    else
                        base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
