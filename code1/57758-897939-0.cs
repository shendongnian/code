    private void treeView1_MouseDown(object sender, MouseEventArgs e)
    {
       TreeNode clickedNode = treeView1.GetNodeAt(e.X, e.Y);
       if (NodeBounds(clickedNode).Contains(e.X, e.Y))
       {
          if (treeView1.SelectedNode != clickedNode)
          {
             treeView1.SelectedNode = clickedNode;
             treeView1.LabelEdit = false;
          }
          else
          {
             treeView1.LabelEdit = true;
          }
       }
    }
