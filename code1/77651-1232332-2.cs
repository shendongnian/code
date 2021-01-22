    public interface IReadOnlyList<T> : IEnumerable<T>
    {
        int Count { get; }
        T this[int index] { get; }
    }
