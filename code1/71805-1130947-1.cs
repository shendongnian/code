    protected void GridView1_ItemCommand(object source, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            //Redirect to user page information
            Response.Redirect("UserProfilePage.aspx?userID=" + e.CommandArgument);
        }
    }
