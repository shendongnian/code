    class TabMessageFilter : IMessageFilter
    {
        public bool TabState { get; set; }
        public bool PreFilterMessage(ref Message m)
        {
            const int WM_KEYUP = 0x101;
            const int WM_KEYDOWN = 0x100;
            switch (m.Msg)
            {
                case WM_KEYDOWN:
                    if ((Keys)m.WParam == Keys.Tab) TabState = true;
                    break;
                case WM_KEYUP:
                    if ((Keys)m.WParam == Keys.Tab) TabState = false;
                    break;
            }
            return false;
        }
    }
    class MainForm : Form
    {
        TabMessageFilter tabFilter;
        public MainForm()
        {
             tabFilter = new TabMessageFilter();
             Application.AddMessageFilter(tabFilter);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
             Application.RemoveMessageFilter(tabFilter);
             base.OnFormClosed(e);
        }
        void control_Enter(object sender, EventArgs e)
        {
             if (tabFilter.TabState) // do something
             else // do domething else
        }
    }
