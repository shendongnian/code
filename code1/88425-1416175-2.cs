    class Program
    {
      [Hunger()]
      static void Main(string[] args)
      {
      }
      public sealed class HungerAttribute : Attribute
      {
        private readonly Hungry? _HungerLevel;
        public Hungry? HungerLevel { get { return _HungerLevel; } }
        public bool IsNull { get { return !_HungerLevel.HasValue; } }          
        public HungerAttribute()
        {
        }
        //Or:
        public HungerAttribute(Hungry level)
        {
          _HungerLevel = level;
        }
      }
      public enum Hungry { Somewhat, Very, CouldEatMySocks }
    }
