    private void lvTasks_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A && e.Control)
        {
         lvTasks.MultiSelect = true;
         foreach (ListViewItem item in lvTasks.Items)
         {
           item.Selected = true;
         }
        }
        if (e.KeyCode == Keys.Delete) 
        for (int i = lvTasks.SelectedItems.Count - 1; i >= 0; i--)
        {
         ListViewItem itm = lvTasks.SelectedItems[i];
         lvTasks.Items[itm.Index].Remove();
        }
    }
