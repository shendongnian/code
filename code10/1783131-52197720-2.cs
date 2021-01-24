    public class Operation<I> where I : IAnimal
    {
            public Operation() : this(new DogConstructor())
            { }
    
            public Operation(IConstructor constructor)
            {
                IAnimal animal = constructor.Construct("myDog"); // <<<<<<<< Error here!
            }
    }
