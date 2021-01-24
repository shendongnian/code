    public static IEnumerable<object> Merge(IEnumerable<float> list1, IEnumerable<int> list2) {
        using (var enumerator1 = new SmartEnumerator<float>( list1.GetEnumerator() ))
        using (var enumerator2 = new SmartEnumerator<int>( list2.GetEnumerator() )) {
            while (!enumerator1.IsCompleted && !enumerator2.IsCompleted) {
                if (enumerator1.Peek() < enumerator2.Peek()) {
                    yield return enumerator1.Pull();
                } else {
                    yield return enumerator2.Pull();
                }
            }
            while (!enumerator1.IsCompleted) {
                yield return enumerator1.Pull();
            }
            while (!enumerator2.IsCompleted) {
                yield return enumerator2.Pull();
            }
        }
    }
    public class SmartEnumerator<T> : IDisposable {
        private readonly IEnumerator<T> target;
        private bool hasValue;
        private T Value => target.Current;
        public bool IsCompleted {
            get {
                RequestNextValueIfNeeded();
                return !hasValue;
            }
        }
        public SmartEnumerator(IEnumerator<T> target) {
            this.target = target;
        }
        public void Dispose() {
            target.Dispose();
        }
        public T Peek() {
            if (IsCompleted && !hasValue) throw new InvalidOperationException( "Enumerator is already completed" );
            RequestNextValueIfNeeded();
            return Value;
        }
        public T Pull() {
            if (IsCompleted && !hasValue) throw new InvalidOperationException( "Enumerator is already completed" );
            RequestNextValueIfNeeded();
            hasValue = false;
            return Value;
        }
        // Helpers
        private void RequestNextValueIfNeeded() {
            if (!hasValue) RequestNextValue();
        }
        private void RequestNextValue() {
            hasValue = target.MoveNext();
        }
    }
