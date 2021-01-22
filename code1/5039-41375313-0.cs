    public class Tree<T> : List<Tree<T>>
    {
        public  T Data { get; private set; }
        public Tree(T data)
        {
            this.Data = data;
        }
        public Tree<T> Add(T data)
        {
            var node = new Tree<T>(data);
            this.Add(node);
            return node;
        }
    }
