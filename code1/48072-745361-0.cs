    private void tabControl1_MouseClick(object sender, MouseEventArgs e)
    {
      var tabControl = sender as TabControl;
      var tabs = tabControl.TabPages;
    
      if (e.Button == MouseButtons.Middle)
      {
        tabs.Remove(tabs.Cast<TabPage>()
                .Where((t, i) => tabControl.GetTabRect(i).Contains(e.Location))
                .First());
      }
    }
