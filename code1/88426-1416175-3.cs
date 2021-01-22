    class Program
    {
      [Hunger()]
      static void Main(string[] args)
      {
      }
      public sealed class HungerAttribute : Attribute
      {        
        public Hungry? HungerLevel { get; }
        public bool IsNull => !_HungerLevel.HasValue;
        public HungerAttribute()
        {
        }
        //Or:
        public HungerAttribute(Hungry level)
        {
          HungerLevel = level;
        }
      }
      public enum Hungry { Somewhat, Very, CouldEatMySocks }
    }
