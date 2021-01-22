    public class MyClass
    {
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        private readonly List<Car> cars = new List<Car>();
        public List<Car> Cars { get { return cars; } }
        private readonly List<Home> homes = new List<Home>();
        public List<Home> Homes { get { return homes; } }
        private readonly List<Pet> pets = new List<Pet>();
        public List<Pet> Pets { get { return pets; } }
    }
