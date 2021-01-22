    [ComVisible]
    public interface IUserDefinedClassCollection
    {
        IEnumerator GetEnumerator();
        
        int Count { get; };
        IUserDefinedClass this[int index] { get; }
        int Add(IUserDefinedClass item);
        // etc, other methods like Remove, Clear, ...
    }
