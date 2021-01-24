    public sealed partial class App {
        
        public App() {
            InitializeComponent();
            Container = ConfigureServices();
            Suspending += OnSuspending;
        }
       
        public static IContainer Container { get; set; }
        private IContainer ConfigureServices() {
            //... code removed for brevity
            containerBuilder
                .RegisterType<DefaultFrameProvider>()
                .As<IFrameProvider>()
                .SingleInstance();
                           
            containerBuilder.RegisterType<ViewModelBinder>()
                .As<IViewModelBinder>()
                .SingleInstance();
            
            containerBuilder.RegisterType<AutofacServiceProvider>()
                .As<IServiceProvider>()
            
            containerBuilder.RegisterType<NavigationService>()
                .AsSelf()
                .As<INavigationService>();
            
            
            var container = containerBuilder.Build();
            return container;
        }
        
        protected override void OnLaunched(LaunchActivatedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null) {
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated) {
                    //TODO: Load state from previously suspended application
                }
                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }
            
            //Activating navigation service
            var service = Container.Resolve<INavigationService>();
            
            if (e.PrelaunchActivated == false) {
                if (rootFrame.Content == null) {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate<SomePage, SomePageViewModel>();
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }
        
        public class AutofacServiceProvider : IServiceProvider
            public object GetService(Type serviceType) {
                return App.Container.Resolve(serviceType);
            }
        }
       
       //...
    }
