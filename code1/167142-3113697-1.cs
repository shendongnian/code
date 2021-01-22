    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            if (EnableMenuItem(GetSystemMenu(this.Handle, 0), SC_CLOSE, MF_GRAYED) == -1)
                throw new Win32Exception("The message box did not exist to gray out its X");
        }
        private const int SC_CLOSE = 0xF060;
        private const int MF_GRAYED = 0x1;
        [DllImport("USER32")]
        internal static extern int EnableMenuItem(IntPtr WindowHandle, int uIDEnableItem, int uEnable);
        [DllImport("USER32")]
        internal static extern IntPtr GetSystemMenu(IntPtr WindowHandle, int bReset);
    }
