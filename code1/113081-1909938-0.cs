    if (listbox1.SelectedItems.Count == 0)
    {
        return;
    }
    
    // Do this if you want to clear the second ListBox
    listbox2.Items.Clear();
    foreach (object obj in listbox1.SelectedItems)
    {
        listbox2.Items.Add(obj);
    }
