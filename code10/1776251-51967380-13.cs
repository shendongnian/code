    public abstract class Animal
    {
        public abstract int Size { get; }
    }
    
    public abstract class Params<T> where T : Animal { }
