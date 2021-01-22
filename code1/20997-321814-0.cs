    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    
    {
    
        string OnClickCmd = "window.location='DetailPage.aspx?id=";
    
        if (e.Row.RowType == DataControlRowType.DataRow)
    
        {
    
            OnClickCmd += DataBinder.Eval(e.Row.DataItem, "IdFromDb").ToString() + "'";
    
            e.Row.Attributes.Add("onclick", OnClickCmd);
    
        }
    }
