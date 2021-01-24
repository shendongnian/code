    public class FruitModel {
        public int Id;
        public string Category;
        public string Color;
        public double Price;
        public string Shape;
        public string Nutrients;
    
        static Dictionary<string, Func<FruitModel, string>> catmap = new Dictionary<string, Func<FruitModel, string>> {
            { "Color", fm => fm.Color },
            { "Price", fm => fm.Price.ToString() },
            { "Shape", fm => fm.Shape },
            { "Nutrients", fm => fm.Nutrients },
        };
    
        public string Description {
            get => catmap[Category](this);
        }
    }
