    private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e) {
      int j = 0;
      int total = contextMenuStrip1.Items.Count;
      for (int i = 0; i < total; i++) {
        menu1ToolStripMenuItem.DropDownItems.Insert(j, contextMenuStrip1.Items[0]);
        j++;
      }
      contextMenuStrip1.Items.Add("dummy");
    }
