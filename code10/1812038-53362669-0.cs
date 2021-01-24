    int x = 0;
    foreach (ListItem lst in DDLisSec.Items)
    {
    if (x != DDLisSec.SelectedIndex)
    {
    lst.Attributes.Add("style", "color:gray;");
    lst.Attributes.Add("disabled", "true");
    
    }
    x++;
    }
