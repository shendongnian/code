    public interface IExistable<in TValue>
    {
        bool Exists(TValue value);
    }
    public interface IDerivedA : IExistable<int>
    {
    }
    public interface IDerivedB : IExistable<int>, IExistable<string>
    {
    }
