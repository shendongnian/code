    void myProcedure()
    {
      // Hookup a DrawMode Event Handler
      this.myTV.DrawNode += myTV_DrawNode;
      // Set DrawMode and HideSelection
      this.myTV.DrawMode = TreeViewDrawMode.OwnerDrawText;
      this.myTV.HideSelection = false;
      // Make sure the TreeView has Focus
      this.myTV.Focus();
      // Make sure the TreeView is Selected
      this.myTV.Select();
      // If the TreeView has a Node, I want to select the first Node to demonstrate.
      if (this.myTV.Nodes.Count > 0)
      {
        // Make sure the node is visible
        this.myTV.Nodes[0].EnsureVisible();
        // Make sure the Node is Selected
        this.myTV.SelectedNode = myTV.Nodes[0];
      }
      // Make sure the SelectedNode IS the Node that we programmatically want to select.
      textBox1.Text = this.myTV.SelectedNode.Text;
      // if we display sanityCheck1 string, it actually is the correct node.text
      // Make sure .NET runtime knows the Node is selected
      textBox1.Text += "  is Selected = " + this.myTV.SelectedNode.IsSelected.ToString();
    }
