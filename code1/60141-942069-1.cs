    public partial class MainForm : Form
    {
        bool windowInitialized;
    
        public MainForm()
        {
            InitializeComponent();
    
            // this is the default
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.WindowsDefaultBounds;
    
            // check if the saved bounds are nonzero and visible on any screen
            if (Settings.Default.WindowPosition != Rectangle.Empty &&
                IsVisibleOnAnyScreen(Settings.Default.WindowPosition))
            {
                // first set the bounds
                this.StartPosition = FormStartPosition.Manual;
                this.DesktopBounds = Settings.Default.WindowPosition;
    
                // afterwards set the window state to the saved value (which could be Maximized)
                this.WindowState = Settings.Default.WindowState;
            }
            else
            {
                // this resets the upper left corner of the window to windows standards
                this.StartPosition = FormStartPosition.WindowsDefaultLocation;
    
                // we can still apply the saved size
                // msorens: added gatekeeper, otherwise first time appears as just a title bar!
                if (Settings.Default.WindowPosition != Rectangle.Empty)
                {
                    this.Size = Settings.Default.WindowPosition.Size;
                }
            }
            windowInitialized = true;
        }
    
        private bool IsVisibleOnAnyScreen(Rectangle rect)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.IntersectsWith(rect))
                {
                    return true;
                }
            }
    
            return false;
        }
    
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
    
            // only save the WindowState if Normal or Maximized
            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                case FormWindowState.Maximized:
                    Settings.Default.WindowState = this.WindowState;
                    break;
    
                default:
                    Settings.Default.WindowState = FormWindowState.Normal;
                    break;
            }
    
            # region msorens: this code does *not* handle minimized/maximized window.
    
            // reset window state to normal to get the correct bounds
            // also make the form invisible to prevent distracting the user
            //this.Visible = false;
            //this.WindowState = FormWindowState.Normal;
            //Settings.Default.WindowPosition = this.DesktopBounds;
    
            # endregion
    
            Settings.Default.Save();
        }
    
        # region window size/position
        // msorens: Added region to handle closing when window is minimized or maximized.
    
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            TrackWindowState();
        }
    
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            TrackWindowState();
        }
    
        // On a move or resize in Normal state, record the new values as they occur.
        // This solves the problem of closing the app when minimized or maximized.
        private void TrackWindowState()
        {
            // Don't record the window setup, otherwise we lose the persistent values!
            if (!windowInitialized) { return; }
    
            if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowPosition = this.DesktopBounds;
            }
        }
    
        # endregion window size/position
    }
