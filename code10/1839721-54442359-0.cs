    List<string> selectedValues = new List<string>();
    
    for(int i = 0; i < CheckBoxList1.Items.Count(); i++)
    {
        ListItem item = CheckBoxList1.Items[i] as ListItem;
        if(item != null)
        {
            if(item.Selected == true)
            {
                selectedValues.Add(item.Value);
            }
        }
    }
