    List<ListItem> remove = new List<ListItem>();
    foreach(ListItem li in ItemOrdere2.Items) {
        if(li.Selected) remove.Add(li);
    }
    foreach(ListItem li in remove) {
        ItemOrderer2.Remove(li); // or similar
    }
