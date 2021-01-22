    Array itemValues = System.Enum.GetValues(typeof(Response));
    Array itemNames = System.Enum.GetNames(typeof(Response));
    
    for (int i = 0; i <= itemNames.Length - 1 ; i++) {
        ListItem item = new ListItem(itemNames(i), itemValues(i));
        dropdownlist.Items.Add(item);
    }
