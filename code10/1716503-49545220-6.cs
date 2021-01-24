    enum UnitOfMeasure
    {
        Inches, Feet, Yards, Centimeters, Meters
    }
    class Size
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public UnitOfMeasure Units { get; set; }
    }
