    public interface Animal
    {   
        Poo Excrement { get; }
    }
    public class Poo
    {
    }
    public class RadioactivePoo
    {
    }
    public class AnimalBase<T>
    {   
        public virtual T Excrement
        { 
            get { return default(T); } 
        }
    }
    public class Dog : AnimalBase<Poo>
    {  
        // No override, just return normal poo like normal animal
    }
    public class Cat : AnimalBase<RadioactivePoo>
    {  
        public override RadioactivePoo Excrement 
        {
            get { return new RadioactivePoo(); } 
        }
    }
}
