    public class Node
    {
        // Has Some Data!
        public List<Branch> BranchesIn;
        public List<Branch> BranchesOut;  // assuming this is a directed graph
    }
    
    public class Branch
    {
        // Contains references to Nodes
        public Node NodeA
        public Node NodeB
    }
