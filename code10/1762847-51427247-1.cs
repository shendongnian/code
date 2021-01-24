    protected void ProjectGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
            if (e.CommandName == "GetData")
            {
               GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
               Label myLabel = (Label)row.FindControl("LinkProjectID");
               PopUpMessage(myLabel.Text);
             }
    }
