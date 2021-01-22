    public struct HistorialDateRange
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public double Confidence { get; } /* range [0.0, 1.0] */
    }
