    public class Coordinate
    { 
        public int X { get; set; } = 34; // get or set auto-property with initializer
    
        public int Y { get; } = 89;      // read-only auto-property with initializer
               
        public int Z { get; }            // read-only auto-property with no initializer
                                         // so it has to be initialized from constructor    
    
        public Coordinate()              // .ctor()
        {
            Z = 42;
        }
    }
