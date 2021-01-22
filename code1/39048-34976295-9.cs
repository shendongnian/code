    public interface IMonoid<T> where T : IMonoid<T>
    {
        static T operator +(T t1, T t2);
        static T Zero { get; }
    }
