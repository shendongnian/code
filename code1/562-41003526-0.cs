    // Global Private Variable to hold right-clicked Node
    private TreeNode _currentNode = new TreeNode();
    // Set Global Variable to the Node that was right-clicked
    private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            _currentNode = e.Node;
    }
    // Do something when the Menu Item is clicked using the _currentNode
    private void toolStripMenuItem_Clicked(object sender, EventArgs e)
    {
        if (_currentNode != null)
            MessageBox.Show(_currentNode.Text);
    }
