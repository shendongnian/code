    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if ((e.Exception != null) && (e.ExceptionHandled))
        {
            errorLabel.Text = "Machine group could not be deleted.  This is probably because machines still exist for the group.";
        }
    }
