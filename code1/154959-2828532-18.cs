    internal class ChipmunkEnumerator<T> : IEnumerator<T> {
        private readonly IEnumerator<T> _internal;
        private T _previous;
        private bool _isValid;
        public ChipmunkEnumerator(IEnumerator<T> e) {
            _internal = e;
            _isValid = false;
        }
        public bool IsValid {
            get { return _isValid; }
        }
        public T Previous {
            get { return _previous; }
        }
        public T Current {
            get { return _internal.Current; }
        }
        public bool MoveNext() {
            if (_isValid)
                _previous = _internal.Current;
            return (_isValid = _internal.MoveNext());
        }
        public void Dispose() {
            _internal.Dispose();
        }
        #region Explicit Interface Members
        object System.Collections.IEnumerator.Current {
            get { return Current; }
        }
        void System.Collections.IEnumerator.Reset() {
            _internal.Reset();
            _previous = default(T);
            _isValid = false;
        }
        #endregion
        
    }
