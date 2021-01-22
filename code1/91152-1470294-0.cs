        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
        
                SHChangeNotifyEntry changeEntry = new SHChangeNotifyEntry();
        
                changeEntry.dwEventMask = (uint)SHCNE.SHCNE_CREATE;
                changeEntry.Recursive = false;
                changeEntry.pszWatchDir = "\\My Documents\\";
        
                try
                {
                    bool result = SHChangeNotifyRegister(this.Handle, ref changeEntry);
                }
                catch (Exception ee)
                {
        
                }
            }
        
            [DllImport("aygshell.dll")]
            private static extern bool SHChangeNotifyRegister(IntPtr hwnd, ref SHChangeNotifyEntry test);
        
            private void Form1_Load(object sender, EventArgs e)
            {
        
            }
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct SHChangeNotifyEntry
        {
            public uint dwEventMask;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszWatchDir;
            public bool Recursive;
        }
    }
