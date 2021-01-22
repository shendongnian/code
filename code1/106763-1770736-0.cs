     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)e.Row.FindControl("AcceptBtn")).CommandArgument = myFiles[fileIndex].Name;
            ((LinkButton)e.Row.FindControl("DenyBtn")).CommandArgument = myFiles[fileIndex].Name;
        }
    }
