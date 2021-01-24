    if (e.KeyCode == Keys.Delete) 
    {
       while (lvTasks.SelectedItems.Count > 0)
       {
          lvTasks.Items[0].Remove();
       }
    }
