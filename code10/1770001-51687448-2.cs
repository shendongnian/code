    public partial class SplashScreen : Form
    {
        public Theme LoadedTheme { get; private set; }
    
        public SplashScreen()
        {
            InitializeComponent();
        }
    
        public void SplashScreen_Load(object sender, EventArgs e)
        {
            bwSplashScreenWorker.RunWorkerAsync();
        }
    
        public void bwSplashScreenWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Load in your data here
            LoadedTheme = LoadTheme();
        }
    
        public void bwSplashScreenWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
