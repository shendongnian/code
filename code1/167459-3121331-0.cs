    public class LogOn : Page
    {
        private static object _delaySync = new object();
        private void Authenticate()
        {
            lock(_delaySync)
            {
                 if(password != expected_password)
                 {
                     Thread.Sleep(2000);
                 }
            }
        }
    }
