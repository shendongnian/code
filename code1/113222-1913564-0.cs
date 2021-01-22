    public class SaveableEnumerable<T> : IEnumerable<T>, IDisposable
    {
        public class SaveableEnumerator : IEnumerator<T>
        {
            private IEnumerator<T> enumerator;
            internal SaveableEnumerator(IEnumerator<T> enumerator)
            {
                this.enumerator = enumerator;
            }
            public void Dispose() { }
		
            internal void ActuallyDispose()
            {
                enumerator.Dispose();
            }
            public bool MoveNext()
            {
                return enumerator.MoveNext();
            }
            public void Reset()
            {
                enumerator.Reset();
            }
            public T Current
            {
                get { return enumerator.Current; }
            }
            object IEnumerator.Current
            {
                get { return enumerator.Current; }
            }
        }
        private SaveableEnumerator enumerator;
        public SaveableEnumerable(IEnumerable<T> enumerable)
        {
            this.enumerator = new SaveableEnumerator(enumerable.GetEnumerator());
        }
        public IEnumerator<T> GetEnumerator()
        {
            return enumerator;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return enumerator;
        }
        public void Dispose()
        {
            enumerator.ActuallyDispose();
        }
    }
