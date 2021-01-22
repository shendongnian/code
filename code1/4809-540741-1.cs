    Array itemValues = Enum.GetValues(typeof(TaskStatus));
    Array itemNames = Enum.GetNames(typeof(TaskStatus));
    for (int i = 0; i <= itemNames.Length; i++)
    {
        ListItem item = new ListItem(itemNames.GetValue(i).ToString(),
        itemValues.GetValue(i).ToString());
        ddlStatus.Items.Add(item);
    }
