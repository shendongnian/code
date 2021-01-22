    void sampleGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label bl = (Label)e.Row.FindControl("1234");
        bl.Text= ((DataRowView) e.Row.DataItem)["ID"].ToString();
      }
    }
