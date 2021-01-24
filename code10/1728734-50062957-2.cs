    public class FixedSizeQueue<T> : IEnumerable<T> {
        private Queue<T> queue;
        public FixedSizeQueue(int capacity) {
            Capacity = capacity;
            queue = new Queue<T>(capacity);
        }
        public int Capacity { get; private set; }
        public int Count
        {
            get { return queue.Count; }
        }
        public void Clear() {
            queue.Clear();
        }
        public T Enqueue(T item) {
            queue.Enqueue(item);
            if (queue.Count > Capacity) {
                return queue.Dequeue();
            }
            else {
                //if you want this to do something else, such as return the `peek` value
                //modify as desired.
                return default(T);
            }
        }
        public T Peek() {
            return queue.Peek();
        }
        public IEnumerator<T> GetEnumerator() {
            return ((IEnumerable<T>) this.queue).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
