    public class Truck
    {
        private static const string defaultName = "Super Truck";
        private static const int defaultTires = 4;
    
        // Use properties for public members (not public fields)
        public string Name { get; set; }
        public int Tires { get; set; }
    
        public Truck()
        {
            Name = defaultName;
            Tires = defaultTires;
        }
    
        public void ResetTruck()
        {
            Name = defaultName;
            Tires = defaultTires;
        }
    
    }
