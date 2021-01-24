    public interface IAnimal {
        IOwner Owner { get; }
    }
    
    public abstract class Mammal : IAnimal { ... }
    
    public class Dog : Mammal { ... }
