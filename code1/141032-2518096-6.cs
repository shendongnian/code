    static class Program
    {
        static SplashForm _splash;
    
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            _splash = new SplashForm();
            _splash.Show();
            _splash.Refresh();
            Application.EnableVisualStyles();
            MainForm mainForm = new MainForm();
            mainForm.Load += new EventHandler(mainForm_Load);
            Application.Run(mainForm);
        }
    
        static void mainForm_Load(object sender, EventArgs e)
        {
            _splash.Dispose();
        }
    }
