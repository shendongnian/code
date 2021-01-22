    public interface IAnimal
    {
        string GetName();
        string Talk();
    }
    
    public abstract class AnimalBase : IAnimal
    {
        private string _name;
    
        // Constructor #1
        protected AnimalBase(string name)
        {
            _name = name;
        }
    
        // Constructor #2
        protected AnimalBase(string name, bool isCutsey)
        {
            if (isCutsey)
            {
                // Change "Fluffy" into "Fluffy-poo"
                _name = name + "-poo";
            }
        }
    
        // GetName implemention from IAnimal.
        // In C#, "virtual" means "Let the child class override this if it wants to but is not required to"
        public virtual string GetName()
        {
            return _name;
        }
    
        // Talk "implementation" from IAnimal.
        // In C#, "abstract" means "require our child classes to override this and provide the implementation".
        // Since our base class forces child classes to provide the implementation, this takes care of the IAnimal implementation requirement.
        abstract public string Talk();
    }
    
    public class Dog : AnimalBase
    {
        // This constructor simply passes on the name parameter to the base class's constructor.
        public Dog(string name)
            : base(name)
        {
        }
    
        // This constructor passes on both parameters to the base class's constructor.
        public Dog(string name, bool isCutsey)
            : base(name, isCutsey)
        {
        }
    
        // Override the base class's Talk() function here, and this satisfy's AnimalBase's requirement to provide this implementation for IAnimal.
        public override string Talk()
        {
            return "Woof! Woof!";
        }
    }
    
    public class SmallDog : Dog
    {
        private bool _isPurseDog;
    
        // This constructor is unique from all of the other constructors.
        // Rather than the second boolean representing the "isCutsey" property, it's entirely different.
        // It's entirely a coincidence that they're the same datatype - this is not important.
        // Notice that we're saying ALL SmallDogs are cutsey by passing a hardcoded true into the base class's (Dog) second parameter of the constructor.
        public SmallDog(string name, bool isPurseDog)
            : base(name, true)
        {
            _isPurseDog = isPurseDog;
        }
    
        // This tells us if the dog fits in a purse.
        public bool DoesThisDogFitInAPurse()
        {
            return _isPurseDog;
        }
    
        // Rather than using Dog's Talk() implementation, we're changing this because this special type of dog is different.
        public override string Talk()
        {
            return "Yip! Yip!";
        }
    }
    
    public class Chihuahua : SmallDog
    {
        private int _hatSize;
    
        // We say that Chihuahua's always fit in a purse. Nothing else different about them, though.
        public Chihuahua(string name, int hatSize)
            : base(name, true)
        {
            _hatSize = hatSize;
        }
    
        // Of course all chihuahuas wear Mexican hats, so let's make sure we know its hat size!
        public int GetHatSize()
        {
            return _hatSize;
        }
    }
    
    public class Cat : AnimalBase
    {
        // This constructor simply passes on the name parameter to the base class's constructor.
        public Cat(string name)
            : base(name)
        {
        }
    
        // This constructor passes on both parameters to the base class's constructor.
        public Cat(string name, bool isCutsey)
            : base(name, isCutsey)
        {
        }
    
        // Override the base class's Talk() function here, and this satisfy's AnimalBase's requirement to provide this implementation for IAnimal.
        public override string Talk()
        {
            return "Meoooowwww...";
        }
    }
    
    public class Lion : Cat
    {
        public Lion(string name)
            : base(name)
        {
        }
    
        // Rather than using Cat's Talk() implementation, we're changing this because this special type of cat is different.
        public override string Talk()
        {
            return "ROAR!!!!!!!!";
        }
    }
