    class PriorityQueue<T> {
        SortedList<int, T> _list;
        public PriorityQueue() {
            _list = new SortedList<int, T>();
        }
        public void Enqueue(T item, int priority) {
            _list.Add(priority, item);
        }
        public T Dequeue() {
            T item = _list[0];
            _list.RemoveAt(0);
            return item;
        }
    }
