    public class Resource
    {
        public ConcurrentAccessProvider<int> CapacityAccessProvider { get; }
        private int _capacity;
        public Resource()
        {
            CapacityAccessProvider = new ConcurrentAccessProvider<int>(() => _capacity, val => _capacity = val);
        }
        public int Capacity
        {
            get => CapacityAccessProvider.Get();
            set => CapacityAccessProvider.Set(value);
        }
    }
    public class Consumer
    {
        private readonly int _sleep;
        public Consumer(int sleep)
        {
            _sleep = sleep;
        }
        public void ConsumeResource(Resource resource)
        {
            resource.CapacityAccessProvider.Access(() =>
            {
                var capture = resource.Capacity;
                Thread.Sleep(_sleep);   // some calsulations and stuff
                if (resource.Capacity != capture)
                    throw new SystemException("Something went wrong");
                resource.Capacity -= 1;
                Console.WriteLine(resource.Capacity);
            });
        }
    }
