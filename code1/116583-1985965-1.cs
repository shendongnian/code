    protected void gvBarcode_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
         HyperLink hlParent = (HyperLink)e.Row.FindControl("hlParent");
       }
    }
