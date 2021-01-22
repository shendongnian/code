    // GetSelectedIndices
    foreach (int i in ListBox1.GetSelectedIndices())
    {
        // ListBox1.Items[i] ...
    }
    
    // Items collection
    foreach (ListItem item in ListBox1.Items)
    {
        if (item.Selected)
        {
            // item ...
        }
    }
    
    // LINQ over Items collection (must cast Items)
    var query = from ListItem item in ListBox1.Items where item.Selected select item;
    foreach (ListItem item in query)
    {
        // item ...
    }
    // LINQ lambda syntax
    var query = ListBox1.Items.Cast<ListItem>().Where(item => item.Selected);
