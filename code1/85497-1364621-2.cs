    namespace VideoDemo2
    {
        public partial class App : Application
        {
            public static string userIP;
            public App()
            {
                this.Startup += this.Application_Startup;
                this.Exit += this.Application_Exit;
                this.UnhandledException += this.Application_UnhandledException;
    
                InitializeComponent();
            }
    
            private void Application_Startup(object sender, StartupEventArgs e)
            {
                this.RootVisual = new MainPage();
                App.userIP = e.InitParams["txtUserIP"];
            }
    ...}
