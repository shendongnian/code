    protected void SomeDataGrid_DataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
           System.Data.DataRowView dr = (System.Data.DataRowView)e.Row.DataItem;
           string aVar = dr["DataFieldIdLikePlease"].ToString();
       }
    }
