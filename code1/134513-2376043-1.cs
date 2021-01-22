    public partial class App : Application
    {
        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Process unhandled exception do stuff below
            // Prevent default unhandled exception processing
            e.Handled = true;
        }
    }
