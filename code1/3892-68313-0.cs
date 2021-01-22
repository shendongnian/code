    abstract class Animal<LegType> where LegType : Leg
    {
        public abstract LegType GetLeg();
    }
    
    abstract class Leg { }
    
    class Dog : Animal<DogLeg>
    {
        public override DogLeg GetLeg()
        {
            return new DogLeg();
        }
    }
    
    class DogLeg : Leg { }
