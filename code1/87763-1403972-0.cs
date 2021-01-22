     ListViewItem itemToAdd;
     bool exists = false;
     foreach (ListViewItem item in yourListView.Items)
     {
        if(item == itemToAdd)
        {
           exists=true; 
           break; // Break the loop if the item found.
        }
     }
     if(!exists)
     {
        yourListView.Items.Add(itemToAdd);
     }
     else
     {
        MessageBox.Show("This item already exists");
     }
