    void mnulevel3_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == System.Windows.Forms.MouseButtons.Right)
      {
        ToolStripMenuItem mnusel = (ToolStripMenuItem)sender;
        mnusel.DoDragDrop(mnusel, DragDropEffects.Copy);
      }
    }
    private void listView1_DragDrop(object sender, DragEventArgs e)
    {
      try
      {
        // see the contained types
        var formats = e.Data.GetFormats();
        Array.ForEach(formats, item => Debug.WriteLine("Supported format: " + item.ToString()));
    
        ToolStripItem mmnu = e.Data.GetData(typeof(ToolStripItem)) as ToolStripItem;
    
        String menuitemstr = mmnu.Text;
        ListViewItem lv = new ListViewItem(menuitemstr);
        listView1.Items.Add(lv);
      }
      catch(Exception ex)
      {
        Debug.WriteLine("listView1_DragDrop exception: " + ex);
      }
    }
