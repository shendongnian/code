    using System.Diagnostics;
    //...
    public class MyWindow : System.Windows.Forms.IWin32Window
    {
        private IntPtr _hwnd;
        public IntPtr Handle
        {
            get
            {
                return _hwnd;
            }
        }
        public MyWindow(IntPtr handle)
        {
            _hwnd = handle;
        }
        //...
        public static MyWindow GetWindowFromName(string processName)
        {
            Process[] procs = Process.GetProcessesByName(processName);
            if (procs.Length != 0)
            {
                return new MyWindow(procs[0].MainWindowHandle);
            }
            else
            {
                throw new ApplicationException(String.Format("{0} is not running", processName));
            }
        }
    }
    //...
    tip.Show("this worked...", MyWindow.GetWindowFromName("Notepad"), 0, 0, 2000);
