    static void Main()
    {
        Application.SetCompatibleTextRenderingDefault(false);
        SplashForm splash = new SplashForm();
        splash.Show();
        splash.Refresh(); // make sure the splash draws itself properly
        Application.EnableVisualStyles();
        Application.Run(new MainForm(splash));
    }
    public partial class MainForm : Form
    {
        SplashForm _splash;
        public MainForm(SplashForm splash)
        {
            _splash = splash;
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // do all my expensive loading here
            _splash.Close();
        }
    }
