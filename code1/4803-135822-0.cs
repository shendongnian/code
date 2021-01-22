    foreach (Response r in Enum.GetValues(typeof(Response)))
    {
        ListItem item = new ListItem(Enum.GetName(typeof(Response), r), r.ToString());
        DropDownList1.Items.Add(item);
    }
