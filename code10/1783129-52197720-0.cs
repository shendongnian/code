    public interface IAnimal
    {
            string Name { get; }
    }
    
    public class Dog : IAnimal
    {
            public string Name { get; set; }
    
            public Dog(string name)
            {
                this.Name = name;
            }
    }
    
    public class Cat : IAnimal
    {
            public string Name { get; set; }
    
            public Cat(string name)
            {
                this.Name = name;
            }
    }
    
    public class Operation<I> where I : IAnimal
    {
            public Operation() : this(new DogConstructor())
            { }
    
            public Operation(IConstructor constructor)
            {
                I animal = constructor.Construct("myDog"); // <<<<<<<< Error here!
            }
    }
