    public partial class MainWindow : Window
    {
        [DllImport("DwmApi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(
            IntPtr hwnd,
            ref MARGINS pMarInset);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr DefWindowProc(
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam);
        private const int WM_NCHITTEST = 0x0084;
        private const int HTBORDER = 18;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Obtain the window handle for WPF application
                IntPtr mainWindowPtr = new WindowInteropHelper(this).Handle;
                HwndSource mainWindowSrc = HwndSource.FromHwnd(mainWindowPtr);
                mainWindowSrc.CompositionTarget.BackgroundColor = Color.FromArgb(0, 0, 0, 0);
                mainWindowSrc.AddHook(WndProc);
                // Set Margins
                MARGINS margins = new MARGINS();
                margins.cxLeftWidth = 10;
                margins.cxRightWidth = 10;
                margins.cyBottomHeight = 10;
                margins.cyTopHeight = 10;
                int hr = DwmExtendFrameIntoClientArea(mainWindowSrc.Handle, ref margins);
                //
                if (hr < 0)
                {
                    //DwmExtendFrameIntoClientArea Failed
                }
            }
            // If not Vista, paint background white.
            catch (DllNotFoundException)
            {
                Application.Current.MainWindow.Background = Brushes.White;
            }
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // Override the window hit test
            // and if the cursor is over a resize border,
            // return a standard border result instead.
            if (msg == WM_NCHITTEST)
            {
                handled = true;
                var htLocation = DefWindowProc(hwnd, msg, wParam, lParam).ToInt32();
                switch (htLocation)
                {
                    case HTBOTTOM:
                    case HTBOTTOMLEFT:
                    case HTBOTTOMRIGHT:
                    case HTLEFT:
                    case HTRIGHT:
                    case HTTOP:
                    case HTTOPLEFT:
                    case HTTOPRIGHT:
                        htLocation = HTBORDER;
                        break;
                }
                return new IntPtr(htLocation);
            }
            return IntPtr.Zero;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        public int cxLeftWidth;      // width of left border that retains its size
        public int cxRightWidth;     // width of right border that retains its size
        public int cyTopHeight;      // height of top border that retains its size
        public int cyBottomHeight;   // height of bottom border that retains its size
    };
    <Window x:Class="WpfApplication1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="150" Width="200" 
        Background="Transparent"
        WindowStyle="None"
        ResizeMode="CanResize"
    >
        <Grid Background="White" Margin="10,10,10,10">
            <Button Content="Go Away" Click="Button_Click" Height="20" Width="100" />
        </Grid>
    </Window>
