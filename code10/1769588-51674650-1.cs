    if (e.KeyCode == Keys.Delete) 
    {
       while (lvTasks.SelectedItems.Count > 0)
       {
          lvTasks.SelectedItems[0].Remove();
       }
    }
