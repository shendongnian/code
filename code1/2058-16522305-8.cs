    public partial class App : Application
    {
        public static readonly SingleInstance Singleton = new SingleInstance(typeof(App).FullName);
        [STAThread]
        public static void Main(string[] args)
        {
            // NOTE: if this always return false, close & restart Visual Studio
            // this is probably due to the vshost.exe thing
            Singleton.RunFirstInstance(() =>
            {
                SingleInstanceMain(args);
            });
        }
        public static void SingleInstanceMain(string[] args)
        {
            // standard code that was in Main now goes here
            App app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
