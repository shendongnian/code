    public partial class frmFixedMaximized : Form
    {
        private bool _changing;
        public frmFixedMaximized()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        private void frmFixedMaximized_Shown(object sender, EventArgs e)
        {
            // Make resizing impossible.
            MinimumSize = Size;
            MaximumSize = Size;
        }
        private void frmFixedMaximized_LocationChanged(object sender, EventArgs e)
        {
            if (!_changing) {
                _changing = true;
                try {
                    // Restore maximized state.
                    WindowState = FormWindowState.Minimized;
                    WindowState = FormWindowState.Maximized;
                } finally {
                    _changing = false;
                }
            }
        }
    }
