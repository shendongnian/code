    public sealed partial class App {
        
        public App() {
            InitializeComponent();
            Container = ConfigureServices();
            Suspending += OnSuspending;
        }
       
        public static IContainer Container { get; set; }
        private IContainer ConfigureServices() {
            var containerBuilder = new ContainerBuilder();
            //  Registers all the platform-specific implementations of services.
            containerBuilder.RegisterType<LoggingService>()
                           .As<ILoggingService>()
                           .SingleInstance();
            containerBuilder.RegisterType<SQLitePlatformService>()
                           .As<ISQLitePlatformService>()
                           .SingleInstance();
            containerBuilder.RegisterType<DiskStorageService>()
                           .As<IDiskStorageService>()
                           .SingleInstance();
            containerBuilder.RegisterType<Facade>()
                           .As<IFacade>();
            //...Register ViewModels as well
           
            containerBuilder.RegisterType<SomePageViewModel>()
                .AsSelf();
           
            //...
            var container = containerBuilder.Build();
            return container;
       }
       
       //...
    }
    
