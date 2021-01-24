    private void Form2_Load(object sender, EventArgs e) {
      DataTable GridTable = GetDataTable();
      FillDataTable(GridTable);
      dataGridView2.DataSource = GridTable;
      dataGridView2.Columns.Add(GetBtnColumn());
    }
