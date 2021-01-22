    public partial class MainWindow : Window
    {
        private HwndSource _source;
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            _source = (HwndSource)PresentationSource.FromVisual(this);
            _source.AddHook(HwndSourceHook);
        }
        protected virtual IntPtr HwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // if needed, the singleton will restore this window
            App.Singleton.OnWndProc(hwnd, msg, wParam, lParam, true, true);
            
            // TODO: handle other specific message
            return IntPtr.Zero;
        }
