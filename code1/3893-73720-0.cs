    abstract class Leg { }
    class DogLeg : Leg { }
    interface IAnimal
    {
        Leg GetLeg();
    }
    class Dog : IAnimal
    {
        public override DogLeg GetLeg() { /* */ }
        Leg IAnimal.GetLeg() { return GetLeg(); }
    }
