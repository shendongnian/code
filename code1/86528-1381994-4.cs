    public class WayPoint
    {
        private Chain optional; // consumes IntPtr.Size fixed cost 
    
        public double Latitude  { get; set; }
        public double Longitude { get; set; }
        
        public double Vertical 
        { 
            get { return optional.Get<double>("Vertical") ?? 0.0; }
            set { optional = optional.Set<double>("Vertical", value); } 
        }
    
        [XmlIgnore] // need this pair for every value type  
        public bool VerticalSpecified 
        { 
            get { return optional.Get<double>("Vertical").HasValue;  } 
        }         
        public void ClearVertical()
        {
            optional = optional.ClearValue<double>("Vertical");   
        }
    
        public string Description // setting to null clears it
        { 
            get { return optional.GetRef<string>("Description"); }
            set { optional = optional.SetRef<string>("Description", value); } 
        }
     
        // Horizontal, Position, DilutionOfPrecision etc.
    }
