    public interface IReadOnlyList<T>
    {
        T this[int index] { get; }
        int Count { get; }
    }
