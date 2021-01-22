    protected void ColorNodes(TreeNode root, Color firstColor, Color secondColor)
    {
       Color nextColor;
       foreach (TreeNode childNode in root.Nodes)
       {     
          nextColor = childNode.ForeColor = childNode.Index % 2 == 0 ? firstColor : secondColor;
       
          if (childNode.Nodes.Count > 0)
          {
             // alternate colors for the next node
             if (nextColor == firstColor)
                  ColorNodes(childNode, secondColor, firstColor);
             else
                  ColorNodes(childNode, firstColor, secondColor);
          }
       }
    }
    
      private void frmCaseNotes_Load(object sender, System.EventArgs e)
        {
           foreach (TreeNode rootNode in treeView1.Nodes)
           {
              ColorNodes(rootNode, Color.Goldenrod, Color.DodgerBlue);
           }
        }
