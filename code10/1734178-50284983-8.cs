    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            private void App_Startup(object sender, StartupEventArgs e)
            {
                // Code for before window opens (optional);
    
                var mainWindow = new MainWindow();
                mainWindow.Show();
    
                mainWindow.Closed += Window_Closed;
            }
    
            private void Window_Closed(object sender, EventArgs e)
            {
                // Code for after window closes goes here.
                MessageBox.Show("Goodbye World!");
            }
        }
    }
