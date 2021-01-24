    public class ImmutableCar : Car
    {
        public string Mfg
        {
            get { return base.Mfg; }
        }
    
        public string Model
        {
            get { return base.Model; }
        }
        
        public Terrain TerrainType
        {
            get { return base.TerrainType; }
        }
        
        internal ImmutableCar(string Manufacturer, string CarModel) : base (Manufacturer, CarModel)
        {
        }
    }
