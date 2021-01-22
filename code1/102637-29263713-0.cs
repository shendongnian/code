    System.Collections.SortedList sorted = new System.Collections.SortedList();
             
    foreach (ListItem ll in ListInQuestion.Items)
    {
        sorted.Add(ll.Value, ll.Text);//yes, first value, then text
    }
    ListInQuestion.Items.Clear();
    foreach (String key in sorted.Keys)
    {
        ListInQuestion.Items.Add(new ListItem(sorted[key].ToString(), key));// <-- look here!
    }
