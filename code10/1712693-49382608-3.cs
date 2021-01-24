    public interface ILivingThing
    {
        string ThingName { get; set; }
        int Age { get; set; }
    }  
    
     public class Animal : ILivingThing
     {
         public Animal() { }
         public enum AnimalType { Dog, Shark, Cat};
         public AnimalType Type { get; set; }
         public  string ThingName { get; set; }
         public  int Age { get; set; }
     }
        
     public class Person : ILivingThing
     {
         public Person() { }
         public  string ThingName { get; set; }
         public  int Age { get; set; }
     }
