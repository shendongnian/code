    protected void ColorNodes(TreeNode root)
    {
       foreach (TreeNode childNode in root.Nodes)
       {     
          childNode.ForeColor = childNode.Index % 2 == 0 ? Color.Goldenrod : Color.DodgerBlue;
       
          if (childNode.Nodes.Count > 0)
             ColorNodes(childNode);
       }
    }
    
      private void frmCaseNotes_Load(object sender, System.EventArgs e)
        {
           foreach (TreeNode rootNode in treeView1.Nodes)
           {
              ColorNodes(rootNode);
           }
        }
