    class ClsProducts
    {
        //Constructor
        public ClsProducts()
        {
            Name = "null";
            ProductionRate = 0.0;
        }
        public ClsProducts(string name, double productionRate)
        {
            Name = name;
            ProductionRate = productionRate;
        }
        //Automatic properties with private setters
        public string Name { get; private set; }
        public double ProductionRate { get; private set; }
        
        //since you basically have key value pair, why not use one?
        public KeyValuePair<String,Double>   Forcast{ get; set; }
    }
