    public class Node : ICollection<Node>
    {
        private List<Node> childNodes;
        public Node()
        {
            childNodes = new List<Node>();
        }
        public Node this[int index]
        {
            get { return childNodes[index]; }
            set { childNodes[index] = value; }
        }
        public void Add(Node childNode)
        {
            childNodes.Add(childNode);
        }            
        
        /* Rest of ICollection<T> implementation */
    }
