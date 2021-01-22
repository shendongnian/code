    List<string> selections = new List<string>();
    foreach (ListItem listItem in cblScope.Items)
    {
        if (listItem.Selected)
        {
            selections.Add(listItem.Value);                
        }
    }
    
    Session["selections"] = selections;
