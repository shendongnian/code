    dataGridView1.ColumnCount = view.Columns.Count;
    dataGridView1.RowCount = view.Rows.Count;
    for (int i = 0; i < dataGridView1.RowCount; i++)
    {
      for (int j = 0; j < dataGridView1.ColumnCount; j++)
      {
        dataGridView1[j, i].Value = view.Rows[i][j].ToString();
      }
    }
