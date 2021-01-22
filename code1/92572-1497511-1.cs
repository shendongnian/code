    string strAnswer = String.Empty;
    foreach (ListItem item in rblAnswer.Items)
    {
        if (item.Selected) 
        {
             strAnswer = item.Value;
        }
    }
    
