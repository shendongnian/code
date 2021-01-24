    public partial class ShakeTest : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetCapture(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern IntPtr GetCapture();
        [DllImport("user32.dll")]
        static extern bool ReleaseCapture();
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int HTCAPTION = 2;
        private Point _lastCursorPos;
        private Size _origianlSize;
        public ShakeTest()
        {
            InitializeComponent();
        }
        
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
    
                // We need to get the moment when the user clicked on a non-client area
                case WM_NCLBUTTONDOWN:
                    // We are interested only in a click on a title bar
                    if ((int) m.WParam == HTCAPTION)
                    {
                        // Set the capture so all the mouse input will be handled by this window
                        SetCapture(Handle);
                        // Keep the current cursor position to use it during the moving.
                        _lastCursorPos = Cursor.Position;
                        // Keep the original window size.
                        _origianlSize = Size;
                        // And change the dialog size to whatever you want
                        Size = new Size(300, 300);
                    }
                    break;
                // Once we got the capture, we need to handle mouse moving by ourself
                case WM_MOUSEMOVE:
                    // Check that our window has the capture
                    if (GetCapture() == Handle)
                    {
                        // Change the position of a window
                        Left += Cursor.Position.X - _lastCursorPos.X;
                        Top += Cursor.Position.Y - _lastCursorPos.Y;
                        _lastCursorPos = Cursor.Position;
                    }
                    break;
                // When the left mouse button is released - it's time to release the mouse capture
                case WM_LBUTTONUP:
                    // Check that our window has the capture
                    if (GetCapture() == Handle)
                    {
                        // Release the mouse capture
                        ReleaseCapture();
                        // Restore the size
                        Size = _origianlSize;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
    }
