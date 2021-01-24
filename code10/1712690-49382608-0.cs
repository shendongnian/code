    public class LivingThing
    {
      public string ThingName { get; set; }
      public int Age { get; set; }
    }
    public class Animal : LivingThing
    {
        public Animal() { }
        public enum AnimalType { Dog, Shark, Cat};
        public AnimalType Type { get; set; }
    }
    
    public class Person : LivingThing
    {
        public Person() { }
    }
