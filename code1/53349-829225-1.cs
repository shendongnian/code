    class Quantity
    {
        public decimal Value;
        public UnitOfMeasure Unit;
        public override string ToString() 
        {
            return string.Format("{0} {1}", Value, Unit); 
        }
    }
    class UnitOfMeasure
    {
        public string Name;
        
        public override string ToString() { return Name; }
    }
