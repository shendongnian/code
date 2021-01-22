    public class SingleItemEnumerator : IEnumerator
    {
        public SingleItemEnumerator(object current)
        {
            this.Current = current;
        }
        public bool MoveNext() => false;
        public void Reset()
        { }
        public object Current { get; }
    }
    public class SingleItemEnumerator<T> : IEnumerator<T>
    {
        public SingleItemEnumerator(T current)
        {
            this.Current = current;
        }
        public void Dispose() => (this.Current as IDisposable).Dispose();
        public bool MoveNext() => false;
        public void Reset()
        { }
        public T Current { get; }
        object IEnumerator.Current => this.Current;
    }
