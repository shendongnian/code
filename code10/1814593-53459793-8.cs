    public class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<MainWindowViewModel>();
            container.RegisterType<MainWindow>();
     
            MainWindow mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
    
