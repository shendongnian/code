    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            private void App_Startup(object sender, StartupEventArgs e)
            {
                // Code for before window opens.
    
                var mainWindow = new MainWindow();
                mainWindow.Show();
    
                mainWindow.Closed += Window_closed;
            }
    
            private void Window_closed(object sender, EventArgs e)
            {
                // Code for after window closes goes here.
                MessageBox.Show("Goodbye World!");
            }
        }
    }
