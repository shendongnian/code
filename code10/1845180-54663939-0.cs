    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "btnDelete")
        {   
            int index = (Convert.ToInt32(e.CommandArgument)) % GridView1.PageSize;
    
            //Get row number
            GridViewRow row = GridView1.Rows[index];
        }
    }
