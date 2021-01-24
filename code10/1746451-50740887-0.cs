    string[] selectedValues = this.LstRecipients.Items.Cast<ListItem>()
        .Where(i => i.Selected)
        .Select(i => i.Value)
        .ToArray();
    Session["SelectedItemValues"] = selectedValues;
    /* on next postback you can retrieve the values in this way: */
    var selectedValues = Session["SelectedItemValues"] as string[];
    if (selectedValues != null)
    {
        foreach(ListItem item in this.LstRecipients.Items)
           item.Selected = selectedValues.Contains(item.Value);
    }
