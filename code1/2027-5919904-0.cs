    public partial class App : Application
    {
        private static Mutex SingleMutex;
        public static uint MessageId;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IntPtr Result;
            IntPtr SendOk;
            Win32.COPYDATASTRUCT CopyData;
            string[] Args;
            IntPtr CopyDataMem;
            bool AllowMultipleInstances = false;
            Args = Environment.GetCommandLineArgs();
            // TODO: Replace {00000000-0000-0000-0000-000000000000} with your application's GUID
            MessageId   = Win32.RegisterWindowMessage("{00000000-0000-0000-0000-000000000000}");
            SingleMutex = new Mutex(false, "AppName");
            if ((AllowMultipleInstances) || (!AllowMultipleInstances &amp;&amp; SingleMutex.WaitOne(1, true)))
                {
                new Main();
                }
            else if (Args.Length > 1)
                {
                foreach (Process Proc in Process.GetProcesses())
                    {
                    SendOk = Win32.SendMessageTimeout(Proc.MainWindowHandle, MessageId, IntPtr.Zero, IntPtr.Zero,
                        Win32.SendMessageTimeoutFlags.SMTO_BLOCK | Win32.SendMessageTimeoutFlags.SMTO_ABORTIFHUNG,
                        2000, out Result);
                    if (SendOk == IntPtr.Zero)
                        continue;
                    if ((uint)Result != MessageId)
                        continue;
                    CopyDataMem = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Win32.COPYDATASTRUCT)));
                    CopyData.dwData = IntPtr.Zero;
                    CopyData.cbData = Args[1].Length*2;
                    CopyData.lpData = Marshal.StringToHGlobalUni(Args[1]);
                    Marshal.StructureToPtr(CopyData, CopyDataMem, false);
                    Win32.SendMessageTimeout(Proc.MainWindowHandle, Win32.WM_COPYDATA, IntPtr.Zero, CopyDataMem,
                        Win32.SendMessageTimeoutFlags.SMTO_BLOCK | Win32.SendMessageTimeoutFlags.SMTO_ABORTIFHUNG,
                        5000, out Result);
                    Marshal.FreeHGlobal(CopyData.lpData);
                    Marshal.FreeHGlobal(CopyDataMem);
                    }
                Shutdown(0);
                }
        }
    }
    public partial class Main : Window
    {
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource Source;
            Source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            Source.AddHook(new HwndSourceHook(Window_Proc));
        }
        private IntPtr Window_Proc(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam, ref bool Handled)
        {
            Win32.COPYDATASTRUCT CopyData;
            string Path;
            if (Msg == Win32.WM_COPYDATA)
                {
                CopyData = (Win32.COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(Win32.COPYDATASTRUCT));
                Path = Marshal.PtrToStringUni(CopyData.lpData, CopyData.cbData / 2); 
                if (WindowState == WindowState.Minimized)
                    {
                    // Restore window from tray
                    }
                // Do whatever we want with information
                Activate();
                Focus();
                }
            if (Msg == App.MessageId)
                {
                Handled = true;
                return new IntPtr(App.MessageId);
                }
            return IntPtr.Zero;
        }
    }
    public class Win32
    {
        public const uint WM_COPYDATA = 0x004A;
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int    cbData;
            public IntPtr lpData;
        }
        [Flags]
        public enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL             = 0x0000,
            SMTO_BLOCK              = 0x0001,
            SMTO_ABORTIFHUNG        = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }
        [DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
        public static extern uint RegisterWindowMessage(string lpString);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageTimeout(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam,
            SendMessageTimeoutFlags fuFlags, uint uTimeout, out IntPtr lpdwResult);
    }
