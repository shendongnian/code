    IWebBrowser2 browser = siteObject as IWebBrowser2;
    if (browser != null) hwnd = new IntPtr(browser.HWND);
    (new MyForm(someParam)).ShowDialog(new WindowWrapper(hwnd));
    ...
    // Wrapper class so that we can return an IWin32Window given a hwnd
    public class WindowWrapper : System.Windows.Forms.IWin32Window
    {
        public WindowWrapper(IntPtr handle)
        {
            _hwnd = handle;
        }
    
        public IntPtr Handle
        {
            get { return _hwnd; }
        }
    
        private IntPtr _hwnd;
    }
