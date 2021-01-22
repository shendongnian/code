    // get a LINQ-enabled list of the list items
    List<ListItem> list = new List<ListItem>(ListBoxToSort.Items.Cast<ListItem>());
    // use LINQ to Objects to order the items as required
    list = list.OrderBy(li => li.Text).ToList<ListItem>();
    // remove the unordered items from the listbox, so we don't get duplicates
    ListBoxToSort.Items.Clear();
    // now add back our sorted items
    ListBoxToSort.Items.AddRange(list.ToArray<ListItem>());
