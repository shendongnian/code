    public enum Month
    {
        January =  1, February =  2, March     =  3,
        April   =  4, May      =  5, June      =  6,
        July    =  7, August   =  8, September =  9,
        October = 10, November = 11, December  = 12
    }
    public class Products
    {
        private readonly String name = null;
        private readonly Double productionRate = 0.0;
        private readonly Double[] productionRateForcast = new Double[12];
        public Products(String name, Double productionRate)
        {
            this.name = name;
            this.productionRate = productionRate;          
        }
    
        public String Name { get { return this.name; } }
        public Double ProductionRate { get { return this.productionRate; } }
        public Double this[Month month]
        {
            get { return this.productionRateForcast[month - Month.January]; }
            set { this.productionRateForcast[month - Month.January] = value; }
        }
    }
