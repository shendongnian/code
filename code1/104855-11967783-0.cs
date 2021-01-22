    public class MessageBoxEx
    {
        private static HwndSource source_ = null;
        private static HwndSourceHook hook_ = null;
        static MessageBoxEx()
        {
            try
            {
                // create cached 
                createHwndSource_(GeneralObjects.MainWindowInstance);
                
                hook_ = new HwndSourceHook(HwndSourceHook);
            }
            finally
            {
                if (null == source_ ||
                    null == hook_)
                {
                    source_ = null;
                    hook_ = null;
                }
            }
            
            
        }
        private static void createHwndSource_(Window owner)
        {
            source_ = (HwndSource)PresentationSource.FromVisual(owner);
        }
        
        public static void Initialize_(Window owner = null)
        {
            try
            {
                if (null != owner)
                {
                    if(source_.RootVisual != owner)
                    {
                        createHwndSource_(owner);
                    }
                
                }
            }
            finally
            {
                if (null == source_ ||
                    null == hook_)
                {
                    source_ = null;
                    hook_ = null;
                }
            }
           
            if (null != source_ &&
                null != hook_)
            {
                source_.AddHook(hook_);
            }
            
        }
        public static MessageBoxResult Show(string messageBoxText)
        {
            Initialize_();
            return System.Windows.MessageBox.Show(messageBoxText);
        }
        
        public static MessageBoxResult Show(string messageBoxText, string caption)
        {
            Initialize_();
            return System.Windows.MessageBox.Show(messageBoxText, caption);
        }
        
        public static MessageBoxResult Show(Window owner, string messageBoxText)
        {
            Initialize_(owner);
            return System.Windows.MessageBox.Show(owner, messageBoxText);
        }
        
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
        {
            Initialize_();
            return System.Windows.MessageBox.Show(messageBoxText, caption, button);
        }
        
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption)
        {
            Initialize_(owner);
            return System.Windows.MessageBox.Show(owner, messageBoxText, caption);
        }
        
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            Initialize_();
            return System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
        }
        
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button)
        {
            Initialize_(owner);
            return System.Windows.MessageBox.Show(owner, messageBoxText, caption, button);
        }
        
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            Initialize_();
            return System.Windows.MessageBox.Show(messageBoxText, caption, button, icon, defaultResult);
        }
        
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            Initialize_(owner);
            return System.Windows.MessageBox.Show(owner, messageBoxText, caption, button, icon);
        }
        
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, System.Windows.MessageBoxOptions options)
        {
            Initialize_();
            return System.Windows.MessageBox.Show(messageBoxText, caption, button, icon, defaultResult, options);
        }
        
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            Initialize_(owner);
            return System.Windows.MessageBox.Show(owner, messageBoxText, caption, button, icon, defaultResult);
        }
        
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, System.Windows.MessageBoxOptions options)
        {
            Initialize_(owner);
            return System.Windows.MessageBox.Show(owner, messageBoxText, caption, button, icon, defaultResult, options);
        }
        private enum WM : int
        {
            WM_ACTIVATE = 0x0006
        }
        private static IntPtr HwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if ((int)WM.WM_ACTIVATE == msg &&
                source_.Handle == hwnd &&
                0 == (int)wParam)
            {
                try
                {
                    CenterWindow(lParam);
                }
                finally
                {
                    // remove hook at once after moved message box window.
                    source_.RemoveHook(hook_);
                }
            }
            return IntPtr.Zero;
        }
        
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);
        
        [DllImport("user32.dll")]
        private static extern int MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        private static void CenterWindow(IntPtr hChildWnd)
        {
            System.Drawing.Rectangle recChild = new System.Drawing.Rectangle(0, 0, 0, 0);
            bool success = GetWindowRect(hChildWnd, ref recChild);
            
            int width = recChild.Width - recChild.X;
            int height = recChild.Height - recChild.Y;
            
            System.Drawing.Rectangle recParent = new System.Drawing.Rectangle(0, 0, 0, 0);
            success = GetWindowRect(source_.Handle, ref recParent);
            System.Drawing.Point ptCenter = new System.Drawing.Point(0, 0);
            ptCenter.X = recParent.X + ((recParent.Width - recParent.X) / 2);
            ptCenter.Y = recParent.Y + ((recParent.Height - recParent.Y) / 2);
            
            System.Drawing.Point ptStart = new System.Drawing.Point(0, 0);
            ptStart.X = (ptCenter.X - (width / 2));
            ptStart.Y = (ptCenter.Y - (height / 2));
            // I have commented this code because of I have 2 monitors
            // so If application located at 1st monitor
            // message box can appear at second one.
            /*
            ptStart.X = (ptStart.X < 0) ? 0 : ptStart.X;
            ptStart.Y = (ptStart.Y < 0) ? 0 : ptStart.Y;
            */
            int result = MoveWindow(hChildWnd, ptStart.X, ptStart.Y, width,
                                    height, false);
            
        }
    
    }
