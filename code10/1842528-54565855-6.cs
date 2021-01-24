    public void CreateDataGridView() {
      dataGridView1.Columns.Add("Id", "Id");
      dataGridView1.Columns.Add("Lastname", "Lastname");
      dataGridView1.Columns.Add("City", "City");
      dataGridView1.Columns.Add(GetBtnColumn());
      dataGridView1.Rows.Add("1", "Muller", "Seattle");
      dataGridView1.Rows.Add("2", "Arkan", "Austin");
      dataGridView1.Rows.Add( "3", "Cooper", "New York");
    }
