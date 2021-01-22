      // Make sure the TreeView has Focus
      this.myTV.Focus();
      // Make sure the TreeView is Selected
      this.myTV.Select();
      // Make sure the TreeView has a Node
      if (this.myTV.Nodes.Count > 0)
      {
        // Make sure the Node is Selected
        this.myTV.SelectedNode = LocationTV.Nodes[0];
      }
      // Make sure the SelectedNode IS the Node that we programmatically want to select.
      string sanityCheck1 = this.LocationTV.SelectedNode.Text;
      // if we display sanityCheck1 string, it actually is the correct node.text
      // Make sure .NET runtime knows the Node is selected
      bool isSanityChecked1 = this.LocationTV.Nodes[0].IsSelected;
      // OOPS!, .NET runtime thinks the programmatically selected node is NOT Selected!
      bool isSanityChecked2 = this.LocationTV.SelectedNode.IsSelected;
      // OOPS OOPS!!, .NET runtime things that SelectedNode is NOT Selected?
      
