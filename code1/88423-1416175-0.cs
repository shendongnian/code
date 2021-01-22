    class Program
    {
        [Hunger(null)]
        static void Main(string[] args)
        {
        }
        public class HungerAttribute : Attribute {
            public Hungry HungerLevel { get; set; } 
            public Hungry? NullableHungerLevel { get; set; }
            
            public HungerAttribute(Hungry? level)
            {
                NullableHungerLevel = level;
            }
 
            //Or:
            public HungerAttribute( Hungry level)
            {
                HungerLevel = level;
            }
        }
        public enum Hungry { Somewhat, Very, CouldEatMySocks }
    }
