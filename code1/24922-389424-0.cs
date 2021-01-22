    protected void FormatGridView(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow) 
       {
          ((Button)e.Row.Cells(0).FindControl("btnSpecial")).CommandArgument = e.Row.RowIndex.ToString();
       }
    }
