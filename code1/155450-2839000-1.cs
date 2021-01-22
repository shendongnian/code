    protected void myGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("select", StringComparison.CurrentCultureIgnoreCase))
        {
            int primaryKeyInteger = Convert.ToInt32(e.CommandArgument);
            // Do other stuff ...
        }
    }
