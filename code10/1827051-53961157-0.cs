    class Car
    {
        ...
        
        public static readonly List<Car> Instances = new List<Car>() 
        {
            new Car() {Model = "Honda", Name = "CRV"}, 
            new Car() {Model = "Toyota", Name = "Prius"}, 
            new Car() {Model = "Nissan", Name = "Rogue"}
        };
    }
