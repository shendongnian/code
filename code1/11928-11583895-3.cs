    public class Node<TData, TLeft, TRight>
    {
        public TLeft Left { get; private set; }
        public TRight Right { get; private set; }
        public TData Data { get; private set; }
        public Node(TData x, TLeft l, TRight r){ Data = x; Left = l; Right = r; }
    }
