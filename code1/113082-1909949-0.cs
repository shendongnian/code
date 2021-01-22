    List<object> itemsToRemove = new List<object>();
    
    foreach (var item in listbox2.SelectedItems)
    {
        listbox1.Items.Add(item);
        itemsToRemove.Add(item);
    }
    
    foreach (var item in itemsToRemove)
    {
        listbox2.Items.Remove(item);
    }
