    public class Program
    {
        private static readonly App app = new App() { ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown };
        [STAThread]
        public static void Main()
        {
            LoginWindow login = new LoginWindow();
            login.Closed += Login_Closed;
            app.Run(login);
        }
        private static void Login_Closed(object sender, EventArgs e)
        {
            LoginWindow loginWindow = (LoginWindow)sender;
            loginWindow.Closed -= Login_Closed;
            if (loginWindow.LoggedIn)
            {
                MainWindow mainWindow = new MainWindow();
                app.MainWindow = mainWindow;
                app.ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;
                mainWindow.Show();
            }  
        }
    }
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        public bool LoggedIn { get; private set; }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //if (authenticate)...
            LoggedIn = true;
            Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            LoggedIn = false;
            Close();
        }
    }
