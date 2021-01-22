    public partial class Form1 : Form
    {
        [DllImport("coredll.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        const int GWL_WNDPROC = -4;
        public delegate int WindProc(IntPtr hWnd, uint msg, 
            long Wparam, long lparam);
        private WindProc _SampleProc;
        public Form1()
        {
            InitializeComponent();
            _SampleProc = new WindProc(SubclassWndProc);
            SetWindowLong(this.Handle, GWL_WNDPROC,
                _SampleProc.Method.MethodHandle.Value.ToInt32());
        
        }
        public int SubclassWndProc(IntPtr  hwnd, uint  msg, 
            long  Wparam, long  lparam)
        {
            return 1;
        }
