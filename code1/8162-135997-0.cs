    public class MyDataGridView : DataGridView
    {
        private const uint WM_MOUSEWHEEL = 0x20a;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEWHEEL)
            {
                var wheelDelta = ((int)m.WParam) >> 16;
                if (wheelDelta < 0)
                {
                    SendKeys.Send("{DOWN}");
                }
                if (wheelDelta > 0)
                {
                    SendKeys.Send("{UP}");
                }
                return;
            }
            base.WndProc(ref m);
        }
    }
