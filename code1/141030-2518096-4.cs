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
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // or do all expensive loading here (or in the constructor if you prefer)
            
            _splash.Close();
        }
    }
