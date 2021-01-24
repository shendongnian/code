    public interface IMonoid<T> : ISemiGroup<T>
    {
        T Identity { get; }
    }
    public interface IGroup<T> : IMonoid<T>
     {
        T Inverse(T a);
    }
    public interface IRing<T>
    {
       IGroup<T> AdditiveStructure { get; }
       IMonoid<T> MultiplicativeStructure { get; }
    }
