    public partial class MainPortal : Window
    {
    
        [System.Runtime.InteropServices.DllImport(@"C:\Program Files\Cognos\TM1\bin\tm1api.dll", EntryPoint="TM1APIFinalize")]
        public static extern void TM1APIFinalize();
    
        public MainPortal()
        {
            InitializeComponent();
    
            TM1APIInitialise();
        }
    }
