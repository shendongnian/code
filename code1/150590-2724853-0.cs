    class Branch
    {
        public Branch(Node nodeA, Node nodeB) { NodeA = nodeA; NodeB = nodeB; }
        public Node NodeA { get; set; }
        public Node NodeB { get; set; }
    }
    
    class Node
    {
        public Node(string name) { Name = name; }
        public string Name { get; set; }
    }
...
    List<Node> nodes = new List<Node>() { new Node("Apple"), new Node("Banana") };
    List<Branch> branches = new List<Branch>() { new Branch(nodes[0], nodes[1]), new Branch(nodes[1], nodes[0]) };
    
    Node node = nodes[0];
    nodes.Remove(node);
    
    var query = from branch in branches
                where branch.NodeA == node || branch.NodeB == node 
                select branch;
    
    foreach (Branch branch in query)
    {
        if (branch.NodeA == node)
            branch.NodeA = null;
        if (branch.NodeB == node) // could just be 'else' if NodeA cannot equal NodeB
            branch.NodeB = null;
    }
