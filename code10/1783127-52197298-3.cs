    public interface IConstructor<T> where I: IAnimal
    {
        T Construct(string name);
    }
    public class DogConstructor : IConstructor<Dog>
    {
        Dog Construct(string name)
        {
            return new Dog(name);
        }
    }
    public class Operation<I> where I : IAnimal
    {
        public Operation(IConstructor<I> constructor)
        {
            I animal = constructor.Construct("myDog");
        }
    }
    public class DogOperation: Operation<Dog> {
        public DogOperation() : base(new DogConstructor()) {}
    }
