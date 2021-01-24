    class CottonCandy
    {
        private int Mass { get; set; }
        private int Volume { get; set; }
        private int TotalSugar { get; set; }
        private int Colors { get; set; }
    
        public int this[string field]
        {
            get
            {
                PropertyInfo propertyInfo = typeof(CottonCandy).GetProperty(field);
                if(propertyInfo == null)
                    throw new ArgumentException("Invalid field");
                return (int)propertyInfo.GetValue(this);
            }
        }
    }
