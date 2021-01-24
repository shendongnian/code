    private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (dataGridView2.Columns[e.ColumnIndex].Name == "Edit") {
        dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
        dataGridView2.ReadOnly = false;
        InEditMode2 = true;
      }
    }
    private void dataGridView2_RowLeave(object sender, DataGridViewCellEventArgs e) {
      if (InEditMode2) {
        dataGridView2.ReadOnly = true;
        dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        InEditMode2 = false;
      }
    }
