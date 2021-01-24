    public class AppDomainWrapper : MarshalByRefObject
    {
        public void openUI()
        {
            var application = new System.Windows.Application();
            var ui = new Window();
            application.Run(ui);
            application.Shutdown();
        }
    }
