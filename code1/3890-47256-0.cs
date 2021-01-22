	abstract class Leg { }
	
	interface IAnimal { Leg GetLeg(); }
	
	abstract class Animal<TLeg> : IAnimal where TLeg : Leg
	 { public abstract TLeg GetLeg();
	   Leg IAnimal.GetLeg() { return this.GetLeg(); }
	 }
	
	class Dog : Animal<Dog.DogLeg>
	 { public class DogLeg : Leg { }
	   public override DogLeg GetLeg() { return new DogLeg();}
	 } 
