    public interface Animal
    {
        Poo Excrement { get; }
    }
    public class Poo
    {
    }
    public class RadioActivePoo : Poo
    {
    }
    public class AnimalBase : Animal
    {
        public virtual Poo Excrement { get { return new Poo(); } }
    }
    public class Dog : AnimalBase
    {
        // No override, just return normal poo like normal animal
    }
    public class CatBase : AnimalBase
    {
        public override Poo Excrement { get { return new RadioActivePoo(); } }
    }
    public class Cat : CatBase
    {
        public new RadioActivePoo Excrement { get { return (RadioActivePoo) base.Excrement; } }
    }
