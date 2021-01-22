    public static class MouseInput
    {
        // TME_HOVER
        // The caller wants hover notification. Notification is delivered as a 
        // WM_MOUSEHOVER message.  If the caller requests hover tracking while 
        // hover tracking is already active, the hover timer will be reset.
        private const int TME_HOVER = 0x1;
        private struct TRACKMOUSEEVENT
        {
            // Size of the structure - calculated in the constructor
            public int cbSize;
            // value that we'll set to specify we want to start over Mouse Hover and get
            // notification when the hover has happened
            public int dwFlags;
            // Handle to what's interested in the event
            public IntPtr hwndTrack;
            // How long it takes for a hover to occur
            public int dwHoverTime;
            // Setting things up specifically for a simple reset
            public TRACKMOUSEEVENT(IntPtr hWnd)
            {
                this.cbSize = Marshal.SizeOf(typeof(TRACKMOUSEEVENT));
                this.hwndTrack = hWnd;
                this.dwHoverTime = SystemInformation.MouseHoverTime;
                this.dwFlags = TME_HOVER;
            }
        }
        // Declaration of the Win32API function
        [DllImport("user32")]
        private static extern bool TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);
        public static void ResetMouseHover(IntPtr windowTrackingMouseHandle)
        {
            // Set up the parameter collection for the API call so that the appropriate
            // control fires the event
            TRACKMOUSEEVENT parameterBag = new TRACKMOUSEEVENT(windowTrackingMouseHandle);
            // The actual API call
            TrackMouseEvent(ref parameterBag);
        }
    }
