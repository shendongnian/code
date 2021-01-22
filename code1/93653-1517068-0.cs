    void btnAccept_Click(Object sender, CommandEventArgs e) 
    {
        if (e.CommandName == "Accept")
        {
           string rowId = e.CommandArgument;
           ((Button)sender).Visible = false;
        }
    }
