    public class Length
    {
        public double Inches { get; set; }
        public double Feet
        {
            get { return Inches / 12.0; }
            set { Inches = value * 12.0; }
        }
        public double Meters
        {
            get { return Inches / 39.3700787; }
            set { Inches = value * 39.3700787; }
        }
        public double Furlongs
        {
            get { return Feet / 660.0; }
            set { Feet = value * 660.0; }
        }
        public double Miles
        {
            get { return Furlongs / 8.0; }
            set { Furlongs = Miles * 8.0; }
        }
    }
