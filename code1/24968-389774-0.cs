    protected void FormatGridView(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow) 
       {
          e.Row.Cells[1].Text = GetUserId(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "userid"));
       }
    }
