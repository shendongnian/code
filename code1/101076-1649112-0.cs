    class Node
    {
        public string Name;
        public decimal Time;
        public List<Node> Children = new List<Node>();
        public void PrintNode(string prefix)
        {
            Console.WriteLine("{0} {1} : {2}", prefix, this.Name, this.Time);
            foreach (Node n in Children)
                n.PrintNode(prefix + "|--");
        }
    }
