    public class Operation
    {
        public Operation() : this(new DogConstructor())
        { }
    
        public Operation(IConstructor constructor)
        {
            IAnimal animal = constructor.Construct("myDog");
        }
    }
