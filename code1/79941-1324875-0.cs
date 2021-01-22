    DataGridView.AutoGenerateColumns = true;
    DataGridView.DataSource = dbconnection.getDataReader();
    DataGridView.DataBind();
    int result;
    for (int i = 0; i < DataGridView.Rows.Count; i++)
    {
      foreach (TableCell c in DataGridView.Rows[i].Cells)
      {
        if (int.TryParse(c.Text, out result))
        {
          c.Text = String.Format("{0:n0}", result);
        }
      }
    }
