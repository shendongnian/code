    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell c in e.Row.Cells)
                {
                    c.CssClass = "bgimage";
                }
            }
        }
