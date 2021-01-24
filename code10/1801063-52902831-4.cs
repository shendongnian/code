    using System.Windows;
    namespace WPFSystemTray
    {
    public partial class MainWindow : Window
    {
        private static MainWindow instance;
        public static MainWindow Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainWindow();
                }
                return instance;
            }
        }
        private MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!App.IsExitApplication)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
    }
