    private void renameToolStripMenuItem_Click(object sender, EventArgs e)
    {
          if (treeView1.SelectedNode != null)
          {
              // Do renaming
              TreeNode node = treeView1.SelectedNode;
              node.Text = "New Text";
          }
    }
