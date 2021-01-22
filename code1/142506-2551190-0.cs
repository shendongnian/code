    List<TreeNode> tnc = null;
    private TypeIn()
    {
          tnc  = new List<TreeNode>();
          foreach (TreeNode n in treeView1.Nodes)
          {
              tnc.Add((TreeNode)n.Clone());
          }
          treeView1.Nodes.Clear();
          
    }
