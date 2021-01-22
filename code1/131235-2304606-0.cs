    class Node
    {
        public String Name { get; private set; }
        public IList<Node> Childs { get; private set; }
    
        public Node(String name)
        {
            Name = name;
            Childs = new List<Node>();
        }
    
        public List<Node> Depth
        {
            get
            {
                List<Node> path = new List<Node>();
                foreach (Node node in Childs)
                {
                    List<Node> tmp = node.Depth;
                    if (tmp.Count > path.Count)
                        path = tmp;
                }
                path.Insert(0, this);
                return path;
            }
        }
    
        public override string ToString()
        {
            return Name;
        }
    }
