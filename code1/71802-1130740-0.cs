      protected void GridView1_ItemCommand(object source, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                //Redirect to user page information
                Response.Redirect(PageURL);
            }
        }
    
