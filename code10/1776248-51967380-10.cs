    public abstract class Factory<T> where T : Animal
    {
        public abstract string SpeciesName { get; }
        public abstract Type TypeCreated { get; }
        public abstract T Create(Params<T> args);
    }
    
    public interface ISerialize
    {
        string Serialize(Animal animal);
    }
    
    public abstract class Animal
    {
        public abstract int Size { get; }
    }
    
    public abstract class Params<T> where T : Animal { }
