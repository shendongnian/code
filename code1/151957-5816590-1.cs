    protected void GridView1_PreRender1(object sender, EventArgs e)
    {
      foreach (GridViewRow row in GridView1.Rows)
      {
        string pwd = new string('*', row.Cells[2].Text.Length);
      }
    }
