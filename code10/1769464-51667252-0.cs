      /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string filePath = System.IO.Path.Combine(Environment.GetFolderPath(
        Environment.SpecialFolder.ApplicationData), "Log.txt");
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
              writer.WriteLine("Message :" + e.Exception.Message + "<br/>" + Environment.NewLine + "StackTrace :" + e.Exception.StackTrace +  "" + Environment.NewLine + "Date :" + Now.ToString());
              writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
