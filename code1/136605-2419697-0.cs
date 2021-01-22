    public class Tire
    {
        public float Size {get; set;}
        public string Brand {get; set;}
    }
    
    public class Car
    {
        public List<Tire> Tires {get; private set;}
    }
