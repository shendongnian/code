    class Equipment
    {
        public string Title1 { get; set; }
        public double Title2 { get; set; }
        public string Title3 { get; set; }
        public override string ToString()
        {
           return $"{Title1},{Title2},{Title3}";
        }
    }
