    public class Truck
    {
        private TruckProperties properties = new TruckProperties();
        public Truck()
        {
        }
        public string Name
        {
            get
            {
                return this.properties.Name;
            }
            set
            {
                this.properties.Name = value;
            }
        }
        public int Tires
        {
            get
            {
                return this.properties.Tires;
            }
            set
            {
                this.properties.Tires = value;
            }        
        }
        public void ResetTruck()
        {
            this.properties = new TruckProperties();
        }
    }
