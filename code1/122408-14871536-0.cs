    public class Node<TItem, TKey>
    {
        public TKey Key { get; set; }
        public int Level { get; set; }
        public IEnumerable<TItem> Data { get; set; }
        public List<Node<TItem, TKey>> Children { get; set; }
    }
