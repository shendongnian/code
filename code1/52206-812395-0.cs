    public interface IDeque<T>
    {
        void PushFront(T element);
        T PopFront();
        void PushBack(T element);
        T PopBack();
        int Count { get; }
    }
