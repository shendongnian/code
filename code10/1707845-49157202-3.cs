    public class Service
    {
        public string Name { get; private set; } = Guid.NewGuid().ToString();
    }
    public class Application
    {
        private readonly Service singleton;
        private readonly Service transient;
        public Application(Service singleton, Service transient)
        {
            this.singleton = singleton;
            this.transient = transient;
        }
        public Service Singleton { get { return singleton; } }
        public Service Transient { get { return transient; } }
    }
