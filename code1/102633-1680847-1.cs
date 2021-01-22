    System.Collections.SortedList sorted = new SortedList();
    foreach (ListItem ll in ListBox1.Items)
    {
        sorted.Add(ll.Text, ll.Value);
    }
    ListBox1.Items.Clear();
                        
    foreach (String key in sorted.Keys)
    {
        ListBox1.Items.Add(new ListItem(key, sorted[key].ToString()));
    }
