    public class TruckProperties
    {
        public string Name
        {
            get; 
            set;
        }
        public int Tires
        {
            get; 
            set;
        }
        public TruckProperties()
        {
            this.Name = "Super Truck";
            this.Tires = 4;
        }
        public TruckProperties(string name, int tires)
        {
            this.Name = name;
            this.Tires = tires;
        }
    }
