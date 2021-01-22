       public partial class App : Application
    {
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);
            ResourceDictionary rd = new ResourceDictionary() { Source = new Uri("CommonStyle.xaml",UriKind.RelativeOrAbsolute) };
            this.Resources = rd;
            // Create and show the application's main window
            Intro window = new Intro();
            window.Show();
        }
        public void Activate()
        {
            // Reactivate application's main window
            this.MainWindow.Activate();
        }
    }
