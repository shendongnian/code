	public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetupBootstrapper(Locator.CurrentMutable);
            MainPage = new MainPage();
        }
        private void SetupBootstrapper(IMutableDependencyResolver resolver)
        {
            resolver.RegisterConstant(new Service(), typeof(IService));
            resolver.RegisterLazySingleton(() => new LazyService(), typeof(ILazyService));
            resolver.RegisterLazySingleton(() => new LazyServiceWithDI(
                ServiceProvider.Get<IService>()), typeof(ILazyServiceWithDI));
            // and so on ....
        }
