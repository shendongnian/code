    using System;
    using System.Threading;
    using System.Windows.Forms;
    public partial class MainForm : Form
    {
        #region Dll Imports
        private const int HWND_BROADCAST = 0xFFFF;
    
        private static readonly int WM_MY_MSG = RegisterWindowMessage( "WM_MY_MSG" );
    
        [DllImport( "user32" )]
        private static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
    
        [DllImport( "user32" )]
        private static extern int RegisterWindowMessage(string message);
        #endregion Dll Imports
        static Mutex _single = new Mutex(true, "{4EABFF23-A35E-F0AB-3189-C81203BCAFF1}");
        [STAThread]
        static void Main()
        {
            // See if an instance is already running...
            if (_single.WaitOne(TimeSpan.Zero, true)) {
                // No...start up normally.
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try {
                    Application.Run(new MainForm());
                } catch (Exception ex) {
                    // handle exception accordingly
                } finally {
                    _single.ReleaseMutex();
                }
            } else {
                // Yes...Bring existing instance to top and activate it.
                PostMessage(
                    (IntPtr) HWND_BROADCAST,
                    WM_MY_MSG,
                    new IntPtr(0xCDCD),
                    new IntPtr(0xEFEF));
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MY_MSG) {
                if ((m.WParam.ToInt32() == 0xCDCD) && (m.LParam.ToInt32() == 0xEFEF)) {
                    if (WindowState == FormWindowState.Minimized) {
                        WindowState = FormWindowState.Normal;
                    }
                    // Bring window to front.
                    bool temp = TopMost;
                    TopMost = true;
                    TopMost = temp;
                    // Set focus to the window.
                    Activate();
                }
            } else {
                base.WndProc(ref m);
            }
        }
    }
