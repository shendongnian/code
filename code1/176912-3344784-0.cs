    abstract class Animal
    {
        public abstract Legs { get; }
    }
    
    class Dog : Animal
    {
        public Dog { } 
    
        [InvariantMaximum(4), InvariantMinimum(4)]
        public override Legs { get { return 4; } }
    }
    
    class Labrador : Dog
    {
        public override Legs { get { return 5; } }    // compiler error
    }
    class Chihuahua: Dog
    {
        public override Legs { get { return 4; } }    // OK
    }
