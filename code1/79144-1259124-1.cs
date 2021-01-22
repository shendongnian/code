    public interface IComplexList<out TOutput, in TInput>
        : IEnumerable<TOutput>
        where TOutput : TInput
    {        
        void Add(TInput item);
    }
    
    public interface ISimpleList<T> : IComplexList<T, T>
    {
    }
