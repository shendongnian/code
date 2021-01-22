    public class Portfolio // Somewhat daft class for pedagogic purposes...
    {
        // Cannot be instanitated externally, instead has two 'factory' methods
        private Portfolio(){ }
        // Immutable properties
        public string Property1 { get; private set; }
        public string Property2 { get; private set; }  // Cannot be accessed externally
        public string Property3 { get; private set; }  // Cannot be accessed externally
        // 'Factory' method 1
        public static Portfolio GetPortfolio(string p1, string p2, string p3)
        {
            return new Portfolio() 
            { 
                Property1 = p1, 
                Property2 = p2, 
                Property3 = p3 
            };
        }
        // 'Factory' method 2
        public static Portfolio GetDefault()
        {
            return new Portfolio() 
            { 
                Property1 = "{{NONE}}", 
                Property2 = "{{NONE}}", 
                Property3 = "{{NONE}}" 
            };
        }
    }
