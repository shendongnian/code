    public class Deque<T> : IDeque<T>
    {
        LinkedList<T> list = new LinkedList<T>();
        public void PushFront(T element)
        {
            list.AddFirst(element);
        }
        public T PopFront()
        {
            T result = list.First.Value;
            list.RemoveFirst();
            return result;
        }
        // ... Fill in the rest...
