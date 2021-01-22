    public class SingleItemEnumerator : IEnumerator
    {
        private bool hasMovedOnce;
        public SingleItemEnumerator(object current)
        {
            this.Current = current;
        }
        public bool MoveNext()
        {
            if (this.hasMovedOnce) return false;
            this.hasMovedOnce = true;
            return true;
        }
        public void Reset()
        { }
        public object Current { get; }
    }
    public class SingleItemEnumerator<T> : IEnumerator<T>
    {
        private bool hasMovedOnce;
        public SingleItemEnumerator(T current)
        {
            this.Current = current;
        }
        public void Dispose() => (this.Current as IDisposable).Dispose();
        public bool MoveNext()
        {
            if (this.hasMovedOnce) return false;
            this.hasMovedOnce = true;
            return true;
        }
        public void Reset()
        { }
        public T Current { get; }
        object IEnumerator.Current => this.Current;
    }
