    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceImpl>().As<Service>()
                .OnActivated(e => e.Instance.UnitOfWork = e.Context.Resolve<IUnitOfWork>());
            var container = builder.Build();
            var service = container.Resolve<Service>();
            Console.WriteLine(service.IsUnitOfWorkInjected);
            Console.ReadKey();
        }
    }
    public abstract class Service : IDisposable
    {
        private IUnitOfWork _unitOfWork;
        private static readonly object padlock = new object();
        public IUnitOfWork UnitOfWork
        {
            protected get => _unitOfWork;
            set
            {
                if (_unitOfWork == null)
                {
                    lock (padlock)
                    {
                        if (_unitOfWork == null)
                        {
                            _unitOfWork = value;
                        }
                    }
                }
            }
        }
        public bool IsUnitOfWorkInjected => UnitOfWork != null;
        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    } 
