    class Measurement // Mjerenje
    {
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
    class AnalysisPerDay // AnalizaPoDanu
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Average { get; set; }
    }
