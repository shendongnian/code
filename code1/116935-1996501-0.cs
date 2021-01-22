    public enum HeroTypeValue
    {
        Agility,
        Strength,
        Intelligence   
    }
    public class HeroType
    {
        public HeroTypeValue Value { get; set; }
        public string Description { get; set; }
 
        // ... other properties and possibly behaviour, as needed
        public static HeroType Agility = new HeroType 
                               { 
                                  ID = HeroTypeValue.Agility, 
                                  Description = "Agility" 
                               },
        public static HeroType Strength = new HeroType
                               { 
                                  ID = HeroTypeValue.Strength, 
                                  Description = "Agility" 
                               };
        public static HeroType Intelligence = new HeroType 
                               { 
                                  ID = HeroTypeValue. Intelligence, 
                                  Description = "Intelligence" 
                               };
        public static IEnumerable<HeroType> All = new [] 
        {
            Agility,
            Strength,
            Intelligence
        }
    }
