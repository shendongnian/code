    public abstract class Animal { }
    
    public abstract class Params<T> where T : Animal
    {
        public abstract int Size { get; }
    }
