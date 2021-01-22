    public interface INode<T>
    {
        List<T> Children { get; }
    }
    class TermNode:INode<TermNode>
    {
       public string Name;
       public string Definition;
       public List<TermNode> Children { get; set; }
       public TermNode()
       {
           this.Children = new List<TermNode>();
       }
    }
    public class TreeBuilder<T> where T : INode<T>
    {
        public Func<T, TreeNode> obCreateNodeFunc;
        public void AddNode(TreeView obTreeView, T obNodeToAdd, TreeNode obParentNodeIfAny) 
        {
            TreeNodeCollection obNodes;
            if (obParentNodeIfAny == null)
            {
                obNodes = obTreeView.Nodes;
            }
            else
            {
                obNodes = obParentNodeIfAny.Nodes;
            }
            int iNewNodeIndex = obNodes.Add(obCreateNodeFunc(obNodeToAdd));
            TreeNode obNewNode = obNodes[iNewNodeIndex];
            
            foreach (T child in obNodeToAdd.Children)
            {
                AddNode(obTreeView, child, obNewNode);
            }
        }
    }
    // calling code - Some class
        static TreeNode GetTreeNodeFor(TermNode t)
        {
            return new TreeNode(t.Name);  // or any logic that returns corr TreeNode for T
        }
        void Main()...
        {
           TermNode[] arrNodesList;    
           // populate list with nodes
           
           TreeBuilder<TermNode> tb = new TreeBuilder<TermNode>();
           tb.obCreateNodeFunc = GetTreeNodeFor;
           foreach (TermNode obNode in arrNodesList)
           {
               tb.AddNode(treeView, obNode, null);
           }
        }
