    // Show item in text box
    ListItemCollection clinics = clinicsList.GetItems(query);
     foreach (ListItem item in clinics)
      {
      ListBox1.Items.Add(item.Title);
      }
                    
