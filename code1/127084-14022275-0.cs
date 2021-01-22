    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int WM_POWERBROADCAST = 0x0218;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_SCREENSAVE = 0xF140;
        private const int SC_CLOSE = 0xF060; // dont know
        private const int SC_MONITORPOWER = 0xF170;
        private const int SC_MAXIMIZE = 0xF030; // dont know
        private const int MONITORON = -1;
        private const int MONITOROFF = 2;
        private const int MONITORSTANBY = 1;
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_SYSCOMMAND) //Intercept System Command
            {
                int intValue = wParam.ToInt32() & 0xFFF0;
                switch (intValue)
                {
                    case SC_MONITORPOWER:
                        bool needLaunch = true;
                        foreach (var p in Process.GetProcesses())
                        {
                            if (p.ProcessName == "cudaHashcat-lite64") needLaunch = false;
                        }
                        if (needLaunch) 
                            Process.Start(@"C:\Users\Dron\Desktop\hash.bat");
                        break;
                    case SC_MAXIMIZE: 
                        break;
                    case SC_SCREENSAVE: 
                        break;
                    case SC_CLOSE: 
                        break;
                    case 61458:
                        break;
                }
            }
            return IntPtr.Zero;
        }
    }
