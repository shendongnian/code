    public abstract class Animal<T> 
        where T : Animal<T>
    {
        public string Name {get; private set;}
        public Animal(string name)
        {
            Name = name;
        }
    
        public abstract T Reproduce();  
    
        public static T Reproduce(T animalToReproduce)
        {
            return animalToReproduce.Reproduce();
        }
    
    }
    
    public class Lion : Animal<Lion>
    {
        public Lion(string name)
            : base (name)
        {
    
        }
        public override Lion Reproduce()
        {
            return new Lion(RandomName());
        }
    
    }
