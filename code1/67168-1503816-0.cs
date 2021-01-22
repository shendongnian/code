    namepace ConsoleApplication8
    {
    public class Poo { }
    public class RadioactivePoo : Poo { }
    public interface Animal
    {
        Poo Excrement { get; }
    }
    public class AnimalBase
    {
        public Poo Excrement { get { return ExcrementImpl; } }
        protected virtual Poo ExcrementImpl
        {
            get { return new Poo(); }
        }
    }
    public class Dog : AnimalBase
    {
        // No override, just return normal poo like normal animal
    }
    public class Cat : AnimalBase
    {
        protected override Poo ExcrementImpl
        {
            get { return new RadioactivePoo(); }
        }
        public new RadioactivePoo Excrement { get { return (RadioactivePoo)ExcrementImpl; } }
    }
    }
