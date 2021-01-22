    public class TestListView : System.Windows.Forms.ListView
    {
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        public event EventHandler Scroll;
        protected void OnScroll()
        {
            if (this.Scroll != null)
                this.Scroll(this, EventArgs.Empty);
        }
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL)
                this.OnScroll();
        }
    }
