    public struct Struct
    {
        // Unless you're filling your get/set blocks with anything,
        // these properties will be in-lined in compilation time
        // and will have the same performance/behavior as using public fields
        public decimal A { get; set; }
        public decimal B { get; set; }
        public decimal C { get; set; }
        public decimal D { get; set; }
    }
