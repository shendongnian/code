    private void myTV_DrawNode(object sender, DrawTreeNodeEventArgs e)
    {
      // first, let .NET draw the Node with its defaults
      e.DrawDefault = true;
      // Now update the highlighting or not
      if (e.State == TreeNodeStates.Selected)
      {
        e.Node.BackColor = SystemColors.Highlight;
        e.Node.ForeColor = SystemColors.HighlightText;
      }
      else
      {
        e.Node.BackColor = ((TreeView)sender).BackColor;
        e.Node.ForeColor = ((TreeView)sender).ForeColor;
      }
    }
