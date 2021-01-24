    protected void gwActivity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       GridViewRow row = ((e.CommandSource as Control).NamingContainer as GridViewRow);
       string temp = row.Cells[1].Text;  
       _temp = temp;
    }
