    class Node
    {
        public string Name;
        public decimal Time;
        public List<Node> Children = new List<Node>();
        public void PrintNode(string prefix)
        {
            Console.WriteLine("{0} + {1} : {2}", prefix, this.Name, this.Time);
            foreach (Node n in Children)
                if (Children.IndexOf(n) == Children.Count - 1)
                    n.PrintNode(prefix + "    ");
                else
                    n.PrintNode(prefix + "   |");
        }
    }
