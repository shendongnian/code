    public partial class ImageForm : PerPixelAlphaForm
    {
        public ImageForm()
        {
            InitializeComponent();
        }
        private bool _isNegative;
        private Point _negative;
        private bool _flag;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
            }
        }
        
        protected override void OnResizeEnd(EventArgs e)
        {
            if (_isNegative) {
                Location = _negative;
                _isNegative = false;
            }
        }
        protected override void OnMove(EventArgs e)
        {
            if (Location.Y < 0) {
                _isNegative = true;
                _flag = true;
                _negative = Location;
            }
            else {
                if (_flag) {
                    _flag = false;
                    return;
                }
                _isNegative = false;
            }
        }
    }
