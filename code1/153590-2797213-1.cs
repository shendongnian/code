    class Task<T>
    {
        public T Value { get }
        public bool IsCompleted { get; }
        public void Wait();
    }
