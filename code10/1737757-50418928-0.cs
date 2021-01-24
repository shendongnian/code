    public class DependencyResolver
    {
        static IContainer container;
    
        public DependencyResolver(params Module[] modules)
        {
            var builder = new ContainerBuilder();
    
            if (modules != null)
                foreach (var module in modules)
                    builder.RegisterModule(module);
    
            container = builder.Build();
        }
    
        public T Resolve<T>() => container.Resolve<T>();
        public object Resolve(Type type) => container.Resolve(type);
    }
    
    public partial class App : Application
    {
        public DependencyResolver DependencyResolver { get; }
    
        // Pass here platform specific dependencies
        public App(Module platformIocModule)
        {
            InitializeComponent();
            DependencyResolver = new DependencyResolver(platformIocModule, new IocModule());
            MainPage = new WelcomeView();
        }
    
        /* The rest of the code ... */
    }
