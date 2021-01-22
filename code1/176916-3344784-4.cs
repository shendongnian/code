    public abstract class Animal
    {
        public abstract int Legs {get;}
    }
    public class Dog : Animal
    {
        public sealed override int Legs {get { return 4; } }
    }
    public class Labrador : Dog
    {
        public override int Legs { get; }    // compiler error
    }
