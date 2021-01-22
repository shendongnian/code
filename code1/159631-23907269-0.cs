    public partial class TablessControl : TabControl
        {
            protected override void WndProc(ref Message m)
            {
                // Hide tabs in RunTime mode
                if (m.Msg == 0x1328 && !DesignMode)
                {
                    m.Result = (IntPtr)1;
                }
                // Hide tabs in DesignMode
                else if (m.Msg == 0x1328 && DesignMode)
                {
                    m.Result = (IntPtr)1;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
        }
