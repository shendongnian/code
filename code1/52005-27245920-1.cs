    protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
    
            if (e.Row.RowType == DataControlRowType.Footer)
            {
               e.Row.Cells.RemoveAt(1);
               e.Row.Cells[0].ColumnSpan = 2;
    
            }
            
        }
