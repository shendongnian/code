    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Vehicle<>)).As(typeof(IVehicle<>));
            builder.RegisterGeneric(typeof(Engine<>)).As(typeof(IEngine<>));
            var container = builder.Build();
            var vehicle = container.Resolve<IVehicle<object>>();
            vehicle.Create("1");
            Console.WriteLine(vehicle.EngineCount);
            Console.ReadKey();
        }
    }
    public interface IVehicle<T>
    {
        void Create(string id);
        /// <summary>
        /// This property is just for testing
        /// </summary>
        int EngineCount { get; }
    }
    public class Vehicle<T> : IVehicle<T>
    {
        private readonly Func<IEngine<T>> _engineFactory;
        private Dictionary<string, IEngine<T>> Engines = new Dictionary<string, IEngine<T>>();
        /// <summary>
        /// This property is just for testing
        /// </summary>
        public int EngineCount => Engines.Count;
        public Vehicle(Func<IEngine<T>> engineFactory)
        {
            _engineFactory = engineFactory;
        }
        public void Create(string id)
        {
            IEngine<T> engine = _engineFactory();
            // use engine...
            Engines.Add(id, engine);
        }
    }
    public interface IEngine<T>
    {
    }
    public class Engine<T> : IEngine<T>
    {
    }
