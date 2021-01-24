    public partial class Borderless : Form
    {
        public Borderless() => InitializeComponent();
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            WinApi.Dwm.DWMNCRENDERINGPOLICY Policy = WinApi.Dwm.DWMNCRENDERINGPOLICY.Enabled;
            WinApi.Dwm.WindowSetAttribute(this.Handle, WinApi.Dwm.DWMWINDOWATTRIBUTE.NCRenderingPolicy, (int)Policy);
            if (DWNCompositionEnabled()) { WinApi.Dwm.WindowBorderlessDropShadow(this.Handle, 2); }
            //if (DWNCompositionEnabled()) { WinApi.Dwm.WindowEnableBlurBehind(this.Handle); }
            //if (DWNCompositionEnabled()) { WinApi.Dwm.WindowSheetOfGlass(this.Handle); }
        }
        private bool DWNCompositionEnabled() => (Environment.OSVersion.Version.Major >= 6)
                                             ? WinApi.Dwm.IsCompositionEnabled()
                                             : false;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)WinApi.WinMessage.WM_DWMCOMPOSITIONCHANGED:
                    {
                        WinApi.Dwm.DWMNCRENDERINGPOLICY Policy = WinApi.Dwm.DWMNCRENDERINGPOLICY.Enabled;
                        WinApi.Dwm.WindowSetAttribute(this.Handle, WinApi.Dwm.DWMWINDOWATTRIBUTE.NCRenderingPolicy, (int)Policy);
                        WinApi.Dwm.WindowBorderlessDropShadow(this.Handle, 2);
                        m.Result = (IntPtr)0;
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
    }
