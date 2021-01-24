    public class MyFunkyArray<T> : IEnumerable<T>
    {
        public MyFunkyArray() { }
    
        public MyFunkyArray(T[,] buffer) => Buffer = buffer;
    
        public T[,] Buffer { get; set; }
    
        public T this[(int, int) tuple]
        {
            get => Buffer[tuple.Item1, tuple.Item2];
            set => Buffer[tuple.Item1, tuple.Item2] = value;
        }
    
        public IEnumerator<T> GetEnumerator() => ToEnumerable(Buffer).GetEnumerator();
    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
        public IEnumerable<T> ToEnumerable(Array target) => target.Cast<T>();
    }
