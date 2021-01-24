    public void CreateDataGridView() {
      dataGridView1.ColumnCount = 3;
      dataGridView1.Columns[0].Name = "Id";
      dataGridView1.Columns[1].Name = "Lastname";
      dataGridView1.Columns[2].Name = "City";
      dataGridView1.Rows.Add("1", "Muller", "Seattle");
      dataGridView1.Rows.Add("2", "Arkan", "Austin");
      dataGridView1.Rows.Add( "3", "Cooper", "New York");    }
    }
