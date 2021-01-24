    public class Recursive<T>
    {
        public T Head { get; }
        public IEnumerable<Recursive<T>> Children { get; }
        public Recursive(T head, IEnumerable<Recursive<T>> children)
        {
            Head = head;
            Children = children;
        }
        public Recursive(Recursive<T> source)
        {
            Head = source.Head;
            Children = source.Children;
        }
    }
