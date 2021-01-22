    public class Poo { }
    public class RadioactivePoo : Poo { }
    interface IAnimal
    {
        Poo Excrement { get; }
    }
    public class BaseAnimal<PooType> : IAnimal
        where PooType : Poo, new()
    {
        Poo IAnimal.Excrement { get { return (Poo)this.Excrement; } }
        public PooType Excrement
        {
            get { return new PooType(); }
        }
    }
    public class Dog : BaseAnimal<Poo> { }
    public class Cat : BaseAnimal<RadioactivePoo> { }
