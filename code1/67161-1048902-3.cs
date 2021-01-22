    public class Poo { }
    public class RadioactivePoo : Poo { }
    public class BaseAnimal<PooType> 
        where PooType : Poo, new() 
    {
        PooType Excrement
        {
            get { return new PooType(); }
        }
    }
    public class Dog : BaseAnimal<Poo> { }
    public class Cat : BaseAnimal<RadioactivePoo> { }
