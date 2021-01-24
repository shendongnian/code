    private void lvTasks_KeyDown(object sender, KeyEventArgs e)
    {
        List<int> indexToDelete = new List<int>();
        if (e.KeyCode == Keys.A && e.Control)
        {
          foreach (ListViewItem item in lvTasks.Items)
          {
           indexToDelete.add(item.index)
          }
        }
        if (e.KeyCode == Keys.Delete) 
        for (int i = 0; i < indexToDelete.Count(); i++)
        {
         lvTasks.Items[indexToDelete[i]].Remove();
        }
    }
