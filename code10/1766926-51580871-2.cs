    public partial class frmBlurBehind : Form
    {
        public frmBlurBehind() => InitializeComponent();
        private void frmBlurBehind_Load(object sender, EventArgs e)
        {
            if (CheckAeroEnabled()) { WinApi.Dwm.WindowEnableBlurBehind(this.Handle); }       
        }
        private bool CheckAeroEnabled() => (Environment.OSVersion.Version.Major >= 6) 
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
                        m.Result = (IntPtr)0;
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
    }
