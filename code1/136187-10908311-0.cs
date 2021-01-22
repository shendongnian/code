    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     if (e.Row.RowType == DataControlRowType.Header)
     {
      for (int i = 0; i < GridView1.Columns.Count; i++)
      {
       e.Row.Cells[i].ToolTip = GridView1.Columns[i].HeaderText;
      }
     }
    }
