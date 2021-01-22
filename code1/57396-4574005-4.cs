    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        ///<summary>Gets a value indicating whether this instance is foreground window.</summary>
        ///<value><c>true</c> if this is the foreground window; otherwise, <c>false</c>.</value>
        private bool IsForegroundWindow
        {
            get
            {
                var foreWnd = GetForegroundWindow();
                return ((from f in this.MdiChildren select f.Handle)
                    .Union(from f in this.OwnedForms select f.Handle)
                    .Union(new IntPtr[] { this.Handle })).Contains(foreWnd);
            }
        }
    }
