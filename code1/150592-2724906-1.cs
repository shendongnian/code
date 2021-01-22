    public class Node
    {
        // Has Some Data!
        public List<Branch> BranchesIn;
        public List<Branch> BranchesOut;  // assuming this is a directed graph
        
        public void Delete()
        {
          foreach (var branch in BranchesIn)
            branch.NodeB.BranchesOut.Remove(branch);
          foreach (var branch in BranchesOut)
            branch.NodeA.BranchesIn.Remove(branch);
          BranchesIn.Clear();
          BranchesOut.Clear();
         }
    }
    
    public class Branch
    {
        // Contains references to Nodes
        public Node NodeA
        public Node NodeB
    }
