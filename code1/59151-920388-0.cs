    protected void blah_Command(object sender, CommandEventArgs e)
    {
        string val1 = e.CommandName.ToString();
    
        string [] othervals = e.CommandArgument.ToString().Split(',');
    
    }
