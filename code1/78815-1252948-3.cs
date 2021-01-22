      override protected void OnItemClicked(ToolStripItemClickedEventArgs e)
      {
        if (this.Items.Count == 0)
          base.OnItemClicked(e);
          
        // else do nothing
      }
