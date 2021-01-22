    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // set this.FormBorderStyle to None here if needed
            // if set to none, make sure you have a way to close the form!
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
    }
