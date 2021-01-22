    public interface IEnumerable {
        IEnumerator GetEnumerator();
    }
    public interface IEnumerable<T> : IEnumerable {
        IEnumerator<T> GetEnumerator();
    }
