    /// In App.xaml.cs
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private MainWindow main = new MainWindow();
        private LoginWindow login = new LoginWindow();
        private void Application_Startup(object sender, StartupEventArgs e) {
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            Application.Current.MainWindow = login;
            login.LoginSuccessful += main.StartupMainWindow;
            login.Show();
        }
    }
    /// In LoginWindow.xaml.cs
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        internal event EventHandler LoginSuccessful;
        public LoginWindow() { InitializeComponent(); }
        private void logInButton_Click(object sender, RoutedEventArgs e) {
            LoginSuccessful(this, null);
            Close();
        }
    }
    /// In MainWindow.xaml.cs
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() { InitializeComponent(); }
        internal void StartupMainWindow(object sender, EventArgs e) {
            Application.Current.MainWindow = this;
            Show();
        }
    }
