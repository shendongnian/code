    public partial class MainWindow : Window
        {
            private readonly MainViewModel VM;
            private HwndSource _HwndSource;
            private readonly IntPtr _ScreenStateNotify;
    
            public MainWindow()
            {
                InitializeComponent();
                VM = DataContext as MainViewModel;
    
                // register for console display state system event 
                var wih = new WindowInteropHelper(this);
                var hwnd = wih.EnsureHandle();
                _ScreenStateNotify = NativeMethods.RegisterPowerSettingNotification(hwnd, ref NativeMethods.GUID_CONSOLE_DISPLAY_STATE, NativeMethods.DEVICE_NOTIFY_WINDOW_HANDLE);
                _HwndSource = HwndSource.FromHwnd(hwnd);
                _HwndSource.AddHook(HwndHook);
            }
    
            private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            {
                // handler of console display state system event 
                if (msg == NativeMethods.WM_POWERBROADCAST)
                {
                    if (wParam.ToInt32() == NativeMethods.PBT_POWERSETTINGCHANGE)
                    {
                        var s = (NativeMethods.POWERBROADCAST_SETTING) Marshal.PtrToStructure(lParam, typeof(NativeMethods.POWERBROADCAST_SETTING));
                        if (s.PowerSetting == NativeMethods.GUID_CONSOLE_DISPLAY_STATE)
                        {
                            VM?.ConsoleDisplayStateChanged(s.Data);
                        }
                    }
                }
    
                return IntPtr.Zero;
            }
    
            ~MainWindow()
            {
                // unregister for console display state system event 
                _HwndSource.RemoveHook(HwndHook);
                NativeMethods.UnregisterPowerSettingNotification(_ScreenStateNotify);
            }
        }
