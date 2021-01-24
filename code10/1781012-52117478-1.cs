    public partial class MainWindow
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;
    
            public MainWindow()
            {
                InitializeComponent();
    
                SourceInitialized += OnSourceInitialized;
                Left = 0;
                Top = 0;
            }
    
            private void OnSourceInitialized(object sender, EventArgs e)
            {
                var helper = new WindowInteropHelper(this);
                var source = HwndSource.FromHwnd(helper.Handle);
                source.AddHook(WndProc);
            }
    
            private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            {
    
                switch (msg)
                {
                    case WM_SYSCOMMAND:
                        int command = wParam.ToInt32() & 0xfff0;
                        if (command == SC_MOVE)
                        {
                            handled = true;
                        }
                        break;
                    default:
                        break;
                }
                return IntPtr.Zero;
            }
        }
