    public class PopupForm : Form
    {
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOACTIVATE = 0x0010;
    
        private const int WS_POPUP = unchecked((int)0x80000000);
        private const int WS_BORDER = 0x00800000;
        
        private const int WS_EX_TOPMOST = 0x00000008;
        private const int WS_EX_NOACTIVATE = 0x08000000;
        
        private const int CS_DROPSHADOW = 0x00020000;
    
        private static readonly IntPtr HWND_TOPMOST = (IntPtr)(-1);
    
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    
        public PopupForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);
            Visible = false;
        }
    
        protected virtual void InitializeComponent()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            BackColor = SystemColors.Info;
        
            // ...
        }
    
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_POPUP;
                cp.Style |= WS_BORDER;
                cp.ExStyle |= WS_EX_TOPMOST | WS_EX_NOACTIVATE;
                //if (Microsoft.OS.IsWinXP && SystemInformation.IsDropShadowEnabled)
                //    cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
    
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
    
        public new void Show()
        {
            SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_NOSIZE | SWP_NOMOVE);    
            base.Show();
        }
    
        public void Show(Point p)
        {
            Location = p;
            Show();
        }
    }
