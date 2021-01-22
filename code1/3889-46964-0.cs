    abstract class Animal
    {
      public virtual Leg GetLeg ()
    }
    
    abstract class Leg { }
    
    class Dog : Animal
    {
      public override Leg GetLeg () { return new DogLeg(); }
    }
    
    class DogLeg : Leg { void Hump(); }
