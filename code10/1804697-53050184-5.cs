    ListBoxItem itemToDelete = null;
            
    foreach (ListBoxItem item in listbox.Items)
    {
        if (item.Tag == idToDelete)
        {
            itemToDelete = item;
            break;
        }
    }
    if(itemToDelete != null)
    {
        lbxCustomers.Items.Remove(itemToDelete);
    }
