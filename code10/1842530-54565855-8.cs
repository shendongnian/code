    public DataTable GetDataTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("Id", typeof(string));
      dt.Columns.Add("LastName", typeof(string));
      dt.Columns.Add("City", typeof(string));
      return dt;
    }
    private void FillDataTable(DataTable dt) {
      dt.Rows.Add("1", "Muller", "Seattle");
      dt.Rows.Add("2", "Arkan", "Austin");
      dt.Rows.Add("3", "Cooper", "New York");
    }
    public DataGridViewButtonColumn GetBtnColumn() {
      DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
      btnColumn.Name = "Edit";
      btnColumn.HeaderText = "Edit";
      btnColumn.Text = "Edit";
      btnColumn.UseColumnTextForButtonValue = true;
      return btnColumn;
    }
