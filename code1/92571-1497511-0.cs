    string strAnswer = String.Empty;
    foreach (ListItem item in rblAnswer)
    {
        if (item.Selected) 
        {
             strAnswer = item.Text;
        }
    }
    
