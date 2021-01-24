    public class Fruit
    {
        public int Price { get; set; }
        public string Origins { get; set; }
    }
    public class Banana : Fruit
    {
        public string peelDensity;
        public static Banana AsBanana(Fruit f)
        {
            return f as Banana ?? new Banana { Price = f.Price, Origins = f.Origins };
        }
    }
