    public partial class Borderless : Form
    {
        public Borderless()
        {
            InitializeComponent();
        }
        private void Borderless_Load(object sender, EventArgs e)
        {
            if (CheckAeroEnabled()) {
                WinApi.Dwm.DWMNCRENDERINGPOLICY Policy = WinApi.Dwm.DWMNCRENDERINGPOLICY.Enabled;
                WinApi.Dwm.WindowSetAttribute(this.Handle, WinApi.Dwm.DWMWINDOWATTRIBUTE.NCRenderingPolicy, (int)Policy);
                WinApi.Dwm.WindowBorderlessDropShadow(this.Handle, 2);
                //WinApi.Dwm.WindowSheetOfGlass(this.Handle);
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                return WinApi.Dwm.IsCompositionEnabled();
            }
            return false;
        }
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
